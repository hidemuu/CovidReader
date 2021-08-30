using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository
{
    public static class Urls
    {
        public static readonly string RootPath = PathHelper.GetCurrentRootPath(Constants.RootName);

        public static readonly string SqlLocalConnectionString = RootPath + @"assets\api\db.sqlite";

        public static readonly string SqlCovidConnectionString = RootPath + @"assets\covid\covid.sqlite";

        public static readonly string ServerPath = @"C:\xampp\htdocs\covid_reader\";

        public static readonly string ServerUrl = @"http://localhost:81/covid_reader/";

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
