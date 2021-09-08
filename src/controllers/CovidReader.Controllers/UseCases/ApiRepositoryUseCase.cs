using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Api.Csv;
using CovidReader.Repository.Api.Json;
using CovidReader.Repository.Api.Rest;
using CovidReader.Repository.Api.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Controllers.UseCases
{
    public class ApiRepositoryUseCase
    {
        

        public static IApiRepository UseSqlite()
        {
            var connection = Urls.SqlLocalConnectionString;
            //var backupconnection = "";
            //if (!File.Exists(connection))
            //{
            //    File.Copy(backupconnection, connection);
            //}
            var dbOptions = new DbContextOptionsBuilder<ApiDbContext>().UseSqlite(
                "Data Source=" + connection);
            var r = new SqlApiRepository(dbOptions);
            return r;
        }

        public static IApiRepository UseREST(string url = "", string key = "")
        {
            return new RestApiRepository(url,key);
        }

        public static IApiRepository UseCsv(string path = @"assets\api")
        {
            return new CsvApiRepository(path, "shift-jis");
        }

        public static IApiRepository UseJson(string path = @"assets\api")
        {
            return new JsonApiRepository(path, "shift-jis");
        }

    }
}
