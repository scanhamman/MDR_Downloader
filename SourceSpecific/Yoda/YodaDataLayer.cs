﻿using Dapper;
using Npgsql;

namespace MDR_Downloader.yoda
{
    public class YodaDataLayer
    {
        private readonly string _ctg_connString;
        private readonly string _isrctn_connString;
        private readonly string _yoda_mn_connString;
        
        public YodaDataLayer(Credentials credentials)
        {
            _ctg_connString = credentials.GetConnectionString("ctg");
            _isrctn_connString = credentials.GetConnectionString("isrctn");
            _yoda_mn_connString = credentials.GetConnectionString("yoda");
        }


        public string? FetchSponsorFromNCT(string nct_id)
        {
            using var conn = new NpgsqlConnection(_ctg_connString);
            string sql_string = "Select organisation_name from ad.study_organisations ";
            sql_string += "where sd_sid = '" + nct_id + "' and contrib_type_id = 54;";
            return conn.QueryFirstOrDefault<string>(sql_string);
        }


        public StudyDetails? FetchStudyDetailsFromNCT(string nct_id)
        {
            using var conn = new NpgsqlConnection(_ctg_connString);
            string sql_string = "Select sd_sid, display_title, brief_description, study_type_id from ad.studies ";
            sql_string += "where sd_sid = '" + nct_id + "'";
            return conn.QueryFirstOrDefault<StudyDetails>(sql_string);
        }

        
        public string? FetchSponsorFromISRCTN(string isrctn_id)
        {
            using var conn = new NpgsqlConnection(_isrctn_connString);
            string sql_string = "Select organisation_name from ad.study_organisations ";
            sql_string += "where sd_sid = '" + isrctn_id + "' and contrib_type_id = 54;";
            return conn.QueryFirstOrDefault<string>(sql_string);
        }


        public StudyDetails? FetchStudyDetailsFromISRCTN(string isrctn_id)
        {
            using var conn = new NpgsqlConnection(_isrctn_connString);
            string sql_string = "Select sd_sid, display_title, brief_description, study_type_id from ad.studies ";
            sql_string += "where sd_sid = '" + isrctn_id + "'";
            return conn.QueryFirstOrDefault<StudyDetails>(sql_string);
        }


        public NotRegisteredDetails? FetchNonRegisteredDetailsFromTable(string pp_id)
        {
            using var conn = new NpgsqlConnection(_yoda_mn_connString);
            string sql_string = @"Select sponsor_id, sponsor_name, short_sponsor_name, short_protocol_id,
                                      title, brief_description, study_type_id 
                                      from mn.not_registered 
                                      where sd_sid = '" + pp_id + "'";
            return conn.QueryFirstOrDefault<NotRegisteredDetails>(sql_string);
        }


        public void AddNewNotRegisteredRecord(string pp_id, string title, string short_sponsor_name, string protid)
        {
            using var conn = new NpgsqlConnection(_yoda_mn_connString);
            string sql_string = $@"INSERT INTO mn.not_registered (sd_sid, title, short_sponsor_name, short_protocol_id)
                VALUES ('{pp_id}', '{title}', '{short_sponsor_name}', '{protid}');";
            conn.Execute(sql_string);
        }

    }
}
