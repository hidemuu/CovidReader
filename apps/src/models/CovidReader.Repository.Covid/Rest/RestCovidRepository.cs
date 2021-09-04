using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid
{
    public class RestCovidRepository : ICovidRepository
    {
        private readonly string _url;
        private readonly string _key;

        public RestCovidRepository(string url, string auth)
        {
            if (url == "") url = "https://api.opendata.go.jp/mhlw/";
            _url = url;
            _key = auth;
        }

        public IDeathRepository Deathes => new RestDeathRepository(_url, _key);

        public IHospitalizationRepository Hospitalizations => new RestHospitalizationRepository(_url, _key);

        public IPositiveRepository Positives => new RestPositiveRepository(_url, _key);

        public IRecoveryRepository Recoveries => new RestRecoveryRepository(_url, _key);

        public ISevereRepository Severes => new RestSevereRepository(_url, _key);

        public ITestRepository Tests => new RestTestRepository(_url, _key);

        public ITestDetailRepository TestDetails => new RestTestDetailRepository(_url, _key);

    }
}
