using CovidReader.Repository.Api.Csv;
using CovidReader.Repository.Api.Json;
using CovidReader.Repository.Api.Rest;
using CovidReader.Repository.Api.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api
{
    public class ApiRepositoryUseCase
    {
        public static IApiRepository UseData(DbTypeKeys key)
        {
            IApiRepository data;
            switch (key)
            {
                case DbTypeKeys.Csv: data = UseCsv(); break;
                case DbTypeKeys.Json: data = UseJson(); break;
                case DbTypeKeys.Sql: data = UseSqlite(); break;
                default: 
                    Console.WriteLine("登録されていないパラメータです");
                    data = UseSqlite();
                    break;
            }
            return data;
        }

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

        public static IApiRepository UseREST()
        {
            return new RestApiRepository("","");
        }

        public static IApiRepository UseCsv()
        {
            return new CsvApiRepository(@"assets\api", "shift-jis");
        }

        public static IApiRepository UseJson()
        {
            return new JsonApiRepository(@"assets\api", "shift-jis");
        }

    }
}
