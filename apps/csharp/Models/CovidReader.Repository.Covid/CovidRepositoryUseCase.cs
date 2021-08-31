using CovidReader.Repository.Covid.Csv;
using CovidReader.Repository.Covid.Json;
using CovidReader.Repository.Covid.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid
{
    public class CovidRepositoryUseCase
    {

        public static ICovidRepository UseData(DbTypeKeys key)
        {
            ICovidRepository data;
            switch (key)
            {
                case DbTypeKeys.Csv: data = UseCsv(); break;
                case DbTypeKeys.Sql: data = UseSqlite(); break;
                case DbTypeKeys.Rest: data = UseRest(); break;
                default: 
                    Console.WriteLine("登録されていないパラメータです");
                    data = UseSqlite();
                    break;
            }
            return data;
        }

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

        public static ICovidRepository UseRest()
        {
            return new RestCovidRepository(@"https://api.opendata.go.jp/mhlw/", "PTUGzjZjYAmAtX5uEEVhHXilmAkVZX3y");
        }

        public static ICovidRepository UseCsv()
        {
            return new CsvCovidRepository(@"assets\covid", "shift-jis");
        }

        public static ICovidRepository UseJson()
        {
            return new JsonCovidRepository(@"assets\covid", "shift-jis");
        }

    }
}
