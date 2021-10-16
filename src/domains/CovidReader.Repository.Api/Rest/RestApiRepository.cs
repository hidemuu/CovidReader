using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestApiRepository : IApiRepository
    {
        private readonly string _url;
        private readonly string _key;

        public RestApiRepository(string url, string auth)
        {
            if (url == "") url = "https://api.opendata.go.jp/mhlw/";
            _url = url;
            _key = auth;
        }


        public IInfectionRepository Infections => new RestInfectionRepository(_url, _key);

        public IInspectionRepository Inspections => new RestInspectionRepository(_url, _key);

        public IChartItemRepository ChartItems => new RestChartItemRepository(_url, _key);

        public IChartConfigRepository ChartConfigs => new RestChartConfigRepository(_url, _key);
    }
}
