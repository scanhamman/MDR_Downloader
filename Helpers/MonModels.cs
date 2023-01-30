﻿using Dapper.Contrib.Extensions;
using PostgreSQLCopyHelper;

namespace MDR_Downloader
{
    [Table("sf.source_parameters")]
    public class Source
    {
        public int id { get; set; }
        public int? preference_rating { get; set; }
        public string? database_name { get; set; }
        public bool? uses_who_harvest { get; set; }
        public string? local_folder { get; set; }
        public bool? local_files_grouped { get; set; }
        public int? grouping_range_by_id { get; set; }
        public string? local_file_prefix { get; set; }
        public bool? has_study_tables { get; set; }
        public bool? has_study_topics { get; set; }
        public bool? has_study_features { get; set; }
        public bool? has_study_contributors { get; set; }
        public bool? has_study_references { get; set; }
        public bool? has_study_relationships { get; set; }
        public bool? has_study_links { get; set; }
        public bool? has_study_ipd_available { get; set; }
        public bool? has_object_datasets { get; set; }
        public bool? has_object_dates { get; set; }
        public bool? has_object_relationships { get; set; }
        public bool? has_object_rights { get; set; }
        public bool? has_object_pubmed_set { get; set; }
    }


    [Table("sf.saf_types")]
    public class SFType
    {
        public int id { get; set; }
        public string? name { get; set; }
        public bool? requires_cutoff_date { get; set; }
        public bool? requires_end_date { get; set; }
        public bool? requires_file { get; set; }
        public bool? requires_folder { get; set; }
        public bool? requires_startandendnumbers { get; set; }
        public bool? requires_offsetandamountids { get; set; }
        public bool? requires_search_id { get; set; }
        public bool? requires_prev_saf_ids { get; set; }
        public string? description { get; set; }
        public string? list_order { get; set; }
    }


    [Table("sf.saf_events")]
    public class SAFEvent
    {
        [ExplicitKey]
        public int? id { get; set; }
        public int? source_id { get; set; }
        public DateTime? time_started { get; set; }
        public DateTime? time_ended { get; set; }
        public int? num_records_checked { get; set; }
        public int? num_records_added { get; set; }
        public int? num_records_downloaded { get; set; }
        public int? type_id { get; set; }
        public string? filefolder_path { get; set; }
        public DateTime? cut_off_date { get; set; }
        public DateTime? end_date { get; set; }
        public int? filter_id { get; set; }
        public string? previous_saf_ids { get; set; }
        public int? start_page{ get; set; }
        public int? end_page{ get; set; }
        public int? ids_offset{ get; set; }
        public int? ids_amount { get; set; }
        public string? comments { get; set; }

        public SAFEvent() { }

        public SAFEvent(Options _opts, int? _source_id)
        {
            id = _opts.saf_id;
            source_id = _source_id;
            type_id = _opts.FetchTypeId;
            filefolder_path = _opts.FileName;
            cut_off_date = _opts.CutoffDate;
            end_date = _opts.EndDate;
            filter_id = _opts.FocusedSearchId;
            previous_saf_ids = _opts.previous_saf_ids;
            start_page = _opts.StartPage;
            end_page = _opts.EndPage;
            ids_offset = _opts.OffsetIds;
            ids_amount = _opts.AmountIds;
            time_started = DateTime.Now;
        }
    }


    [Table("sf.source_data_studies")]
    public class StudyFileRecord
    {
        [Key] 
        public int id { get; set; }
        public int? source_id { get; set; }
        public string?sd_id { get; set; }
        public string? remote_url { get; set; }
        public DateTime? last_revised { get; set; }
        public bool? assume_complete { get; set; }
        public int? download_status { get; set; }
        public string? local_path { get; set; }
        public int? last_saf_id { get; set; }
        public DateTime? last_downloaded { get; set; }
        public int? last_harvest_id { get; set; }
        public DateTime? last_harvested { get; set; }
        public int? last_import_id { get; set; }
        public DateTime? last_imported { get; set; }

        // constructor when a revision data can be expected (not always there)
        public StudyFileRecord(int? _source_id, string? _sd_id, string? _remote_url, int? _last_saf_id,
                                              DateTime? _last_revised, string? _local_path)
        {
            source_id = _source_id;
            sd_id = _sd_id;
            remote_url = _remote_url;
            last_saf_id = _last_saf_id;
            last_revised = _last_revised;
            download_status = 2;
            last_downloaded = DateTime.Now;
            local_path = _local_path;
        }

        public StudyFileRecord()
        { }

    }


    [Table("sf.source_data_objects")]
    public class ObjectFileRecord
    {
        [Key]
        public int id { get; set; }
        public int? source_id { get; set; }
        public string? sd_id { get; set; }
        public string? remote_url { get; set; }
        public DateTime? last_revised { get; set; }
        public bool? assume_complete { get; set; }
        public int? download_status { get; set; }
        public string? local_path { get; set; }
        public int? last_saf_id { get; set; }
        public DateTime? last_downloaded { get; set; }
        public int? last_harvest_id { get; set; }
        public DateTime? last_harvested { get; set; }
        public int? last_import_id { get; set; }
        public DateTime? last_imported { get; set; }

        // constructor when a revision data can be expected (not always there)
        public ObjectFileRecord(int? _source_id, string? _sd_id, string?_remote_url, int? _last_saf_id,
                                              DateTime? _last_revised, string? _local_path)
        {
            source_id = _source_id;
            sd_id = _sd_id;
            remote_url = _remote_url;
            last_saf_id = _last_saf_id;
            last_revised = _last_revised;
            download_status = 2;
            last_downloaded = DateTime.Now;
            local_path = _local_path;
        }

        // constructor when a new file record required, when a pmid new to the system is found
        public ObjectFileRecord(int? _source_id, string? _sd_id, string? _remote_url, int? _last_saf_id)
        {
            source_id = _source_id;
            sd_id = _sd_id;
            remote_url = _remote_url;
            last_saf_id = _last_saf_id;
            download_status = 0;
        }

        public ObjectFileRecord()
        { }

    }


    public class DownloadResult
    {
        public int? num_checked { get; set; }
        public int? num_added { get; set; }
        public int? num_downloaded { get; set; }
        public string? error_message { get; set; }

        public DownloadResult()
        {
            num_checked = 0;
            num_added = 0;
            num_downloaded = 0;
        }

        public DownloadResult(string _error_message)
        {
            num_checked = 0;
            num_added = 0;
            num_downloaded = 0;
            error_message = _error_message;
        }

        public DownloadResult(int _num_checked, int _num_added, int _num_downloaded, string _error_message)
        {
            num_checked = _num_checked;
            num_added = _num_added;
            num_downloaded = _num_downloaded;
            error_message = _error_message;
        }
    }


    public class PMCResponse
    {
        public string? status { get; set; }
        public string? responseDate { get; set; }
        public string? request { get; set; }
        public List<NLMRecords>? records { get; set; }
    }


    public class NLMRecords
    {
        public string? pmcid { get; set; }
        public string? pmid { get; set; }
        public string? doi { get; set; }
    }


    [Table("sf.extraction_notes")]
    public class ExtractionNote
    {
        public int? id { get; set; }
        public int? source_id { get; set; }
        public string? sd_id { get; set; }
        public string? event_type { get; set; }
        public int? event_type_id { get; set; }
        public int? note_type_id { get; set; }
        public string? note { get; set; }

        public ExtractionNote(int? _source_id, string? _sd_id, string? _event_type,
                              int? _event_type_id, int? _note_type_id, string? _note)
        {
            source_id = _source_id;
            sd_id = _sd_id;
            event_type = _event_type;
            event_type_id = _event_type_id;
            note_type_id = _note_type_id;
            note = _note;
        }
    }


    public class LoggingCopyHelper
    {
        public PostgreSQLCopyHelper<StudyFileRecord> file_record_copyhelper =
            new PostgreSQLCopyHelper<StudyFileRecord>("sf", "source_data_studies")
                .MapInteger("source_id", x => x.source_id)
                .MapVarchar("sd_id", x => x.sd_id)
                .MapVarchar("remote_url", x => x.remote_url)
                .MapInteger("last_saf_id", x => x.last_saf_id)
                .MapTimeStampTz("last_revised", x => x.last_revised)
                .MapBoolean("assume_complete", x => x.assume_complete)
                .MapInteger("download_status", x => x.download_status)
                .MapTimeStampTz("last_downloaded", x => x.last_downloaded)
                .MapVarchar("local_path", x => x.local_path);

    }

}
