using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestCovid19Repository : ICovid19Repository
    {
        private readonly string _url;
        private readonly string _key;

        public RestCovid19Repository(string url, string auth)
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

        public ICovid19LineItemRepository CovidLineItems => new RestCovid19LineItemRepository(_url, _key);

    }
}
