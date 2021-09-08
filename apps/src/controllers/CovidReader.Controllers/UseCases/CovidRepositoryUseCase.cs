﻿using CovidReader.Repository;
using CovidReader.Repository.Covid;
using CovidReader.Repository.Covid.Csv;
using CovidReader.Repository.Covid.InMemory;
using CovidReader.Repository.Covid.Json;
using CovidReader.Repository.Covid.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Controllers.UseCases
{
    public class CovidRepositoryUseCase
    {

        

        public static ICovidRepository UseSqlite()
        {
            var connection = Urls.SqlCovidConnectionString;
            //var backupconnection = "";
            //if (!File.Exists(connection))
            //{
            //    File.Copy(backupconnection, connection);
            //}
            var dbOptions = new DbContextOptionsBuilder<CovidDbContext>().UseSqlite(
                "Data Source=" + connection);
            var r = new SqlCovidRepository(dbOptions);
            return r;
        }

        public static ICovidRepository UseRest(string url = @"https://api.opendata.go.jp/mhlw/", string key = "PTUGzjZjYAmAtX5uEEVhHXilmAkVZX3y")
        {
            return new RestCovidRepository(url, key);
        }

        public static ICovidRepository UseCsv(string path = @"assets\covid")
        {
            return new CsvCovidRepository(path, "shift-jis");
        }

        public static ICovidRepository UseJson(string path = @"assets\covid")
        {
            return new JsonCovidRepository(path, "shift-jis");
        }

        public static ICovidRepository UseInMemory()
        {
            return new InMemoryCovidRepository();
        }

    }
}
