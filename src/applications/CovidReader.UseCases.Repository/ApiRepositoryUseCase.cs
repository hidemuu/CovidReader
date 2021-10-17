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

namespace CovidReader.UseCases.Repository
{
    /// <summary>
    /// アプリケーションAPIリポジトリ生成のユースケース
    /// </summary>
    public class ApiRepositoryUseCase
    {
        
        /// <summary>
        /// SQLite連携のリポジトリを生成
        /// </summary>
        /// <returns></returns>
        public static IApiRepository UseSqlite()
        {
            var connection = Urls.SqlLocalConnectionStringForSqlite;
            //var backupconnection = "";
            //if (!File.Exists(connection))
            //{
            //    File.Copy(backupconnection, connection);
            //}
            var dbOptions = new DbContextOptionsBuilder<ApiDbContext>().UseSqlite(connection);
            return new SqlApiRepository(dbOptions);
        }

        /// <summary>
        /// PostgreSQL連携のリポジトリを生成
        /// </summary>
        /// <returns></returns>
        public static IApiRepository UsePostgureSql()
        {
            var connection = Urls.SqlLocalConnectionStringForPostgreSql;
            var dbOptions = new DbContextOptionsBuilder<ApiDbContext>().UseNpgsql(connection);
            return new SqlApiRepository(dbOptions);
        }

        /// <summary>
        /// SQLServer連携のリポジトリを生成
        /// </summary>
        /// <returns></returns>
        public static IApiRepository UseSqlServer()
        {
            var connection = Urls.SqlLocalConnectionStringForSqlServer;
            var dbOptions = new DbContextOptionsBuilder<ApiDbContext>().UseSqlServer(connection);
            return new SqlApiRepository(dbOptions);
        }

        /// <summary>
        /// RestAPI連携のリポジトリを生成（将来拡張用）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IApiRepository UseREST(string url = "", string key = "")
        {
            return new RestApiRepository(url,key);
        }

        /// <summary>
        /// Csvファイル連携のリポジトリを生成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApiRepository UseCsv(string path = @"assets\api")
        {
            return new CsvApiRepository(path, "shift-jis");
        }

        /// <summary>
        /// Jsonファイル連携のリポジトリを生成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApiRepository UseJson(string path = @"assets\api")
        {
            return new JsonApiRepository(path, "shift-jis");
        }

    }
}
