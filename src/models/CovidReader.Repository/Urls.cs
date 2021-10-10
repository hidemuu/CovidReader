using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository
{
    /// <summary>
    /// URL一覧
    /// </summary>
    public static class Urls
    {
        /// <summary>
        /// ルートパス（絶対パス）
        /// </summary>
        public static readonly string RootPath = PathHelper.GetCurrentRootPath(Constants.RootName);
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForSqlite = @"Data Source=" + RootPath + @"assets\api\db.sqlite";
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForPostgreSql = @"Host=localhost;Port=5432;User Id=postgres;Password=5285;Database=MobileLinks_db";
        /// <summary>
        /// アプリケーションAPI用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlLocalConnectionStringForSqlServer = @"data source=(LocalDb)\MSSQLLocalDB; initial catalog=MobileLinks.Repository.Sql.MobileLinksDbContext; integrated security=True; MultipleActiveResultSets=True; App=EntityFramework";
        /// <summary>
        /// Covid19 API用ローカルデータベースコネクション文字列
        /// </summary>
        public static readonly string SqlCovidConnectionString = RootPath + @"assets\covid\covid.sqlite";
        /// <summary>
        /// ローカルサーバー用パス（XAMPPを使用する場合のみ）
        /// </summary>
        public static readonly string ServerPath = @"C:\xampp\htdocs\covid_reader\csharp\";
        /// <summary>
        /// ローカルサーバーURL（XAMPPを使用する場合のみ）
        /// </summary>
        public static readonly string ServerUrl = @"http://localhost:81/covid_reader/csharp/";

        /// <summary>
        /// Base URL for the app's API service. A live test service is provided for convenience; 
        /// however, you cannot modify any data on the server or deploy your own updates. 
        /// To see the full functionality, deploy Contoso.Service using your own Azure account.
        /// </summary>
        public const string ApiUrl = @"http://customers-orders-api-prod.azurewebsites.net/api/";

        /// <summary>
        /// The Azure Active Directory (AAD) client id.
        /// </summary>
        public const string AccountClientId = "<TODO: Insert Azure client Id>";

        /// <summary>
        /// Connection string for a server-side SQL database.
        /// </summary>
        public const string SqlAzureConnectionString = "<TODO: Insert connection string>";

        
    }
}
