﻿using System.Text.Encodings.Web;
using System.Text.Json;
using MDR_Downloader.Helpers;

namespace MDR_Downloader.ctg;

class CTG_Controller : IDLController
{
    private readonly IMonDataLayer _monDataLayer;
    private readonly ILoggingHelper _loggingHelper;
    private readonly CtgDataLayer ctg_repo;

    public CTG_Controller(IMonDataLayer monDataLayer, ILoggingHelper loggingHelper)
    {
        _monDataLayer = monDataLayer;
        _loggingHelper = loggingHelper;
        ctg_repo = new CtgDataLayer(_monDataLayer.Credentials);
    }
    
    public async Task<DownloadResult> ObtainDataFromSourceAsync(Options opts, Source source)
    {
        // Data retrieval is normally via an API call to revised files using a cut off revision date, 
        // that date being normally the date of the most recent download.
        // t = 111 is new or revised records (as download) - requires a cutoff date to be supplied or calculated.
        
        // Alternatively a range of Ids can be provided as the basis of the query string - the latter 
        // used during bulk downloads of large numbers of pre-determined files.
        // t = 142 downloads all studies in a specified set of ids - the parameters refer to the initial
        // line number in a numbered list of Id sets, grouped in 10s, and the amount of lines to be 
        // used. Total number of lines is total records / 10 (i.e. about 46,000 - 50,000).
        
        // A third option is to interrogate downloaded json files (e.g. as derived from the
        // bulk download of all CTG data) and re-save them using the local CTG data model.
        // t = 141 is import and re-export of downloaded json files using different data model -
        // requires the path of the parent source folder, offset number of start folder and number of
        // child folders to be checked (0 = all beyond start number).
        // *** This option does not yest seem to ba available with the new API / data structure ***
        
        // The opts.FetchTypeId parameter needs to be inspected to determine which.
        // In all cases new files will be added, and the amended files replaced, as necessary.
        // Begin with general setup, required whichever download option is selected. 
        
        // Note that the two methods using the APi (t = 111 or 142) receive records 10 at a time, 
        // together with a token to be used to fetch the next 10 in the sequence. The total amount 
        // on each call should not be greater than a 1000. These limitations are built into the new API system.

        string? file_base = source.local_folder;
        if (file_base is null)
        {
            _loggingHelper.LogError("Null value passed for local folder value for this source");
            return new DownloadResult();   // return zero result
        }

        int t = opts.FetchTypeId;
        var json_options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        if (t == 111 && opts.CutoffDate is not null)
        {
            return await DownloadRevisedRecords(file_base, (DateTime)opts.CutoffDate, 
                json_options, source.id, (int)opts.dl_id!);
        }
        if (t == 142 && opts.OffsetIds is not null && opts.AmountIds is not null)
        {
            return await DownloadRecordsById(file_base, (int)opts.OffsetIds, (int)opts.AmountIds, 
                json_options, source.id, (int)opts.dl_id!);
        }
        if (t == 141 && !string.IsNullOrEmpty(opts.FileName) 
                     && opts.OffsetIds is not null && opts.AmountIds is not null)
        {
            return await ReexportBulkDownloadedRecords(file_base, opts.FileName, (int)opts.OffsetIds, (int)opts.AmountIds, 
                    json_options, source.id, (int)opts.dl_id!);
        }

        _loggingHelper.LogError("Invalid parameters passed to download controller - unable to proceed");
        return new DownloadResult();   // return zero result

    }

    // The t = 111, new or revised record, option.
    // Cut off date first decomposed so it can be inserted into the API call. An initial call is made to determine the number of records that will be downloaded.
    // This allows the main loop to be established, with study details being downloaded
    // as json files 20 at a time, with a short pause before each download.
    // Each 'batch' of 20 records, i.e. each response body received, is passed to the
    // DownloadBatch routine, which returns a DownloadResult object. The relevant totals 
    // in this object are added to the running totals in the main DownloadResult object,
    // which is returned at the end of the process.

    async Task<DownloadResult> DownloadRevisedRecords(string file_base, DateTime cutoff_date, JsonSerializerOptions json_options,
                                                        int source_id, int dl_id)
    {
        string year = cutoff_date.Year.ToString();
        string month = cutoff_date.Month.ToString("00");
        string day = cutoff_date.Day.ToString("00");

        int min_rank = 1;
        int max_rank = 1;

        string start_url = "https://clinicaltrials.gov/api/query/full_studies?expr=AREA%5BLastUpdatePostDate%5DRANGE%5B";
        string cut_off_params = month + "%2F" + day + "%2F" + year;
        string end_url = "%2C+MAX%5D&min_rnk=" + min_rank + "&max_rnk=" + max_rank + "&fmt=json";
        string url = start_url + cut_off_params + end_url;

        ScrapingHelpers ch = new(_loggingHelper);
        DownloadResult res = new();

        // Do initial search 

        string? responseBody = await ch.GetAPIResponseAsync(url);
        if (responseBody is null)
        {
            _loggingHelper.LogLine($"No response to initial call. Download process aborted");
            return res;       // return zero result
        }
        CTGRootobject? resp = JsonSerializer.Deserialize<CTGRootobject?>(responseBody);
        if (resp is null)
        {
            _loggingHelper.LogLine($"Not able to deserialise response to initial call. Download process aborted");
            return res;       // return zero result
        }
        
        //int? nums_studies_found = resp.FullStudiesResponse?.NStudiesFound;
        /*
        if (nums_studies_found == 0)
        {
            _loggingHelper.LogLine($"No value found for number of studies. Download process aborted");
            return res;     // return zero result
        }

        // otherwise, if all pre-conditions met, go through the identified records 20 at a time.

        int loop_count = nums_studies_found % 20 == 0
                   ? (int)nums_studies_found! / 20
                   : ((int)nums_studies_found! / 20) + 1;

        for (int i = 0; i < loop_count; i++)    
        {
            Thread.Sleep(800);
            min_rank = (i * 20) + 1;
            max_rank = (i * 20) + 20;
            end_url = "%2C+MAX%5D&min_rnk=" + min_rank.ToString() + "&max_rnk=" + max_rank.ToString() + "&fmt=json";
            url = start_url + cut_off_params + end_url;

            responseBody = await ch.GetAPIResponseAsync(url);
            if (responseBody is not null)
            {
                DownloadResult batch_res = await DownloadBatch(responseBody, file_base, json_options, 
                    source_id, dl_id);
                res.num_checked += batch_res.num_checked;
                res.num_downloaded += batch_res.num_downloaded;
                res.num_added += batch_res.num_added;
            }
            else
            {
                _loggingHelper.LogLine($"Null response when requesting {min_rank} to {max_rank}. Download process aborted");
                return res;   // return res in current state - abort process because null response body returned
            }

            if ((i + 1) % 10 == 0)
            {
                string total_count = (i == 9 || (i + 1) % 200 == 0) ? $" (out of {loop_count})" : "";
                _loggingHelper.LogLine($"{res.num_checked} files processed, {res.num_added} added, after {i+ 1} calls "
                                            + total_count);
            }
        }
*/
        return res;   // return aggregated result 
    }

    // The t = 142, download all studies in a specified set of Ids.
    // If all parameters are present the main loop is set up and for each
    // iteration the first and last Ids are derived, for insertion in the 
    // query string. The resulting batch response (usually about 10 studies
    // for any 100 ids) 


    async Task<DownloadResult> DownloadRecordsById(string file_base, int offset, int amount,
                                    JsonSerializerOptions json_options, int source_id, int dl_id)
    {
        ScrapingHelpers ch = new(_loggingHelper);
        DownloadResult res = new();

        // Requirement is to loop through the NCT Id sets, starting with the set
        // on line <offset>, and ending the line before <offset + amount> (so <amount> lines all together
        // Next batch should then start at line <offset + amount>. Initial line has line Id of 0.
        
        int end_id = offset + amount;
        string start_url = "https://clinicaltrials.gov/api/v2/studies?filter.ids=";
        string end_url = "&pageSize=25";
        // Initial task is to establish the table of NCT Id sets.
        
        ctg_repo.EstablishIdTables(); 
        
        for (int i = offset; i < end_id; i++)
        {
            Thread.Sleep(1000);

            // get the NCTId set (max of 10 in each line) corresponding to i
            
            string? id_strings = ctg_repo.FetchIdString(i);
            if (id_strings is null)
            {
                return res;
            }
            
            string url = start_url + id_strings + end_url;
            string? responseBody = await ch.GetAPIResponseAsync(url);
            if (responseBody is not null)
            {
                // need to first switch 'class' to 'nct_class'
                
                responseBody = responseBody.Replace("\"class\":", "\"ctg_class\":");
                DownloadResult batch_res = await DownloadBatch(responseBody, file_base, json_options, 
                               source_id, dl_id);

                res.num_checked += batch_res.num_checked;
                res.num_downloaded += batch_res.num_downloaded;
                res.num_added += batch_res.num_added;

                _loggingHelper.LogLine($"Records checked, line {i}. Downloaded: {batch_res.num_downloaded}");
            }
            else
            {
                _loggingHelper.LogLine($"Null response when requesting line {i} ({id_strings}). Download process aborted");
                return res;   // return res in current state - abort process because null response body returned
            }
        }
        return res;   // return aggregated result data
    }


    // The t = 141 option that takes json files already downloaded via the CTG 'ImportALL' option
    // and which re-exports them using the local CTG model, i.e. with only relevant fields included.

    async Task<DownloadResult> ReexportBulkDownloadedRecords(string file_base, string source_parent_folder, int offset, int amount,
                                                   JsonSerializerOptions json_options, int source_id, int dl_id)
    {
        DownloadResult res = new();

        // Get the folder list in the parent source folder.
        // (Bulk downloads of CTG data provide a parent folder, in which a few hundred
        // child folders each hold the individual files. All are arranged by Id).
        // Order the list by  folder name ( = Id group) and use the first and offset
        // integers to establish the outer loop of folders.

        string[] folder_list = Directory.GetDirectories(source_parent_folder).OrderBy(f => f).ToArray();
        if (!folder_list.Any())
        {
            _loggingHelper.LogLine(
                $"No folders in provided parent source directory {source_parent_folder}. Download process aborted");
            return res; // return zero result
        }
        
        int start_index = offset < folder_list.Length ? offset : folder_list.Length;
        int end_check = (amount == 0 || offset + amount > folder_list.Length) ? folder_list.Length : offset + amount;
        for (int i = start_index; i < end_check; i++)
        {
            // For each folder get the file list - usually hundreds or thousands of files.
            // Loop through each file, de-serialising it against the local CTG model
            // and re-serialising it against the same model. This restricts the fields to those required.
            // The file is then placed in the appropriate MDR CTG data store location.
            // The monitoring database is updated at the same time with download details,
            // and the numbers checked, downloaded and added as new are returned.

            string[] file_list = Directory.GetFiles(folder_list[i]);
            {
                foreach (string file_path in file_list)
                {
                    /*
                    string jsonString = await File.ReadAllTextAsync(file_path);
                    res.num_checked++;
                    FSRootobject? fsr = JsonSerializer.Deserialize<FSRootobject>(jsonString, json_options);
                    if (fsr is not null)
                    {
                        Study? s = fsr.FullStudy?.Study;
                        if (s is not null)
                        {
                            string? sd_sid = s.ProtocolSection?.IdentificationModule?.NCTId;
                            if (sd_sid is not null)
                            {
                                string full_path = await WriteOutFile(s, sd_sid, file_base, json_options);
                                if (full_path != "error")
                                {
                                    string? last_updated_string = s.ProtocolSection?.StatusModule?.LastUpdatePostDateStruct?.LastUpdatePostDate;
                                    DateTime? last_updated = last_updated_string?.FetchDateTimeFromDateString();
                                    string remote_url = "https://clinicaltrials.gov/ct2/show/" + sd_sid;

                                    bool added = _monDataLayer.UpdateStudyLog(sd_sid, remote_url, dl_id,
                                        last_updated, full_path);
                                    res.num_downloaded++;
                                    if (added) res.num_added++;
                                }
                            }
                        }
                        else
                        {
                            _loggingHelper.LogLine($"Unable to get a valid study object from {file_path}. Download process aborted");
                            return res;
                        }
                       
                    }
                    */

                    if (res.num_checked % 1000 == 0)
                    {
                        _loggingHelper.LogLine($"{res.num_checked} files processed so far, folders {start_index} to {i}");
                    }
                }
            }
        }
        return res;
    }

    // The batch processor function - called by both DownloadRevisedRecords and DownloadRecordsById
    // Takes an API response, as a string, and de-serialises it to the CTG json object.
    // Each individual study object is then re-serialised as a json file, this time
    // using the local CTG model, and placed in the appropriate folder.
    // The monitoring database is updated at the same time with download details,
    // and the numbers checked, downloaded and added as new are returned.

    private async Task<DownloadResult> DownloadBatch(string responseBody, string file_base, 
            JsonSerializerOptions json_options, int source_id, int dl_id)
    {
        CTGRootobject? json_resp;
        DownloadResult res = new();

        try
        {
            json_resp = JsonSerializer.Deserialize<CTGRootobject?>(responseBody, json_options);
        }
        catch (Exception e)
        {
            _loggingHelper.LogCodeError("Error with json with " + responseBody[..1000], e.Message, e.StackTrace);
            return res;
        }

        if (json_resp is not null)
        {
            JSONStudy[]? full_studies = json_resp.studies;
            if (full_studies?.Any() is true)
            {
                foreach (JSONStudy s in full_studies)
                {
                    res.num_checked++;
                    // Obtain basic information from the file - enough for 
                    // the details to be filed in source_study_data table.

                    string? sd_sid = s.protocolSection?.identificationModule?.nctId;
                    if (sd_sid is not null)
                    {
                        string full_path = await WriteOutFile(s, sd_sid, file_base, json_options);
                        if (full_path != "error")
                        {
                            string? last_updated_string = s.protocolSection?.statusModule?.lastUpdatePostDateStruct?.date;
                            DateTime? last_updated = last_updated_string?.FetchDateTimeFromISO();
                            string remote_url = "https://clinicaltrials.gov/ct2/show/" + sd_sid;

                            bool added = _monDataLayer.UpdateStudyLog(sd_sid, remote_url, dl_id,
                                                    last_updated, full_path);
                            res.num_downloaded++;
                            if (added) res.num_added++;
                        }
                    }
                }
            }
        }
        return res;
    }


    // Writes out the file with the correct name to the correct folder.
    // Called from both the DownloadBatch and the ReexportBulkDownloadedRecords functions.
    // Returns the full file path as constructed, or an 'error' string if an exception occurred.

    private async Task<string> WriteOutFile(JSONStudy s, string sd_sid, string file_base, 
                      JsonSerializerOptions json_options)
    {
        string file_name = sd_sid + ".json";
        string file_folder = sd_sid[..7] + "xxxx";

        // Then write out study file as indented json

        string folder_path = file_base + file_folder;
        if (!Directory.Exists(folder_path))
        {
            Directory.CreateDirectory(folder_path);
        }

        string full_path = Path.Combine(folder_path, file_name);
        try
        {
            await using FileStream jsonStream = File.Create(full_path);
            await JsonSerializer.SerializeAsync(jsonStream, s, json_options);
            await jsonStream.DisposeAsync();

            if (_monDataLayer.IsTestStudy(sd_sid))
            {
                // write out copy of the file in the test folder
                string test_path = _loggingHelper.TestFilePath;
                string full_test_path = Path.Combine(test_path, file_name);
                await using FileStream jsonStream2 = File.Create(full_test_path);
                await JsonSerializer.SerializeAsync(jsonStream2, s, json_options);
                await jsonStream2.DisposeAsync();
            }
            
            return full_path;
        }
        catch (Exception e)
        {
            _loggingHelper.LogLine("Error in trying to save file at " + full_path + ":: " + e.Message);
            return "error";
        }
    }
}
