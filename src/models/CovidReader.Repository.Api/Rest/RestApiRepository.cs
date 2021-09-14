﻿using System;
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

        public IVirusRepository Viruses => new RestVirusRepository(_url, _key);

        public IInfectionRepository Infections => new RestInfectionRepository(_url, _key);

        public IViralTestRepository ViralTests => new RestViralTestRepository(_url, _key);
        public IInfectionTotalRepository InfectionTotals => new RestInfectionTotalRepository(_url, _key);

        public IViralTestTotalRepository ViralTestTotals => new RestViralTestTotalRepository(_url, _key);

        public IChartItemRepository ChartItems => new RestChartItemRepository(_url, _key);

        public IChartConfigRepository ChartConfigs => new RestChartConfigRepository(_url, _key);
    }
}
