﻿using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MDR_Downloader;

public class Credentials : ICredentials
{
    private readonly string _pubmedAPIKey;
    private readonly string _host;
    private readonly string _username;
    private readonly string _password;
    private readonly int _port;
    
    public Credentials(IConfiguration settings)
    {
        // all asserted as non-null, as settings file 
        // must contain these parameters

        _host = settings["host"]!;
        _username = settings["user"]!;
        _password = settings["password"]!;
        string? PortAsString = settings["port"];
        if (string.IsNullOrWhiteSpace(PortAsString))
        {
            _port = 5432;
        }
        else
        {
            _port = int.TryParse(PortAsString, out int port_num) ? port_num : 5432;
        }
        
        _pubmedAPIKey = settings["pubmed_api_key"]!;
    }

    public string GetConnectionString(string database_name)
    {
        NpgsqlConnectionStringBuilder builder = new()
        {
            Host = _host,
            Username = _username,
            Password = _password,
            Port = _port,
            Database = database_name
        };
        return builder.ConnectionString;
    }
    
    public string GetPubMedApiKey()
    {
        return _pubmedAPIKey;
    }
}