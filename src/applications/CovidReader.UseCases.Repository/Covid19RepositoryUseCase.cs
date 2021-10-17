using CovidReader.Repository;
using CovidReader.Repository.Covid19;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Repository.Covid19.MHLW.Csv;
using CovidReader.Repository.Covid19.MHLW.InMemory;
using CovidReader.Repository.Covid19.MHLW.Json;
using CovidReader.Repository.Covid19.MHLW.Rest;
using CovidReader.Repository.Covid19.MHLW.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.UseCases.Repository
{
    /// <summary>
    /// Covid19 APIリポジトリ生成のユースケース
    /// </summary>
    public class Covid19RepositoryUseCase
    {


        /// <summary>
        /// SQLite連携のリポジトリを生成
        /// </summary>
        /// <returns></returns>
        public static ICovid19Repository UseSqlite()
        {
            var connection = Urls.SqlCovidConnectionString;
            //var backupconnection = "";
            //if (!File.Exists(connection))
            //{
            //    File.Copy(backupconnection, connection);
            //}
            var dbOptions = new DbContextOptionsBuilder<Covid19DbContext>().UseSqlite(
                "Data Source=" + connection);
            var r = new SqlCovid19Repository(dbOptions);
            return r;
        }
        /// <summary>
        /// RestAPI連携のリポジトリを生成
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ICovid19Repository UseRest(string url = @"https://api.opendata.go.jp/mhlw/", string key = "PTUGzjZjYAmAtX5uEEVhHXilmAkVZX3y")
        {
            return new RestCovid19Repository(url, key);
        }
        /// <summary>
        /// Csvファイル連携のリポジトリを生成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ICovid19Repository UseCsv(string path = @"assets\covid")
        {
            return new CsvCovid19Repository(path, "shift-jis");
        }
        /// <summary>
        /// Jsonファイル連携のリポジトリを生成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ICovid19Repository UseJson(string path = @"assets\covid")
        {
            return new JsonCovid19Repository(path, "shift-jis");
        }
        /// <summary>
        /// 内部メモリ連携のリポジトリを生成
        /// </summary>
        /// <returns></returns>
        public static ICovid19Repository UseInMemory()
        {
            return new InMemoryCovid19Repository();
        }

    }
}
