using CovidReader.Core;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class WebController : IController
    {

        private ApiService _apiService;
        private IApiRepository _apiRepository;
        private ICovidRepository _covidRepository;

        public WebController(IApiRepository repository, ICovidRepository covids)
        {
            _apiRepository = repository;
            _covidRepository = covids;
            _apiService = new ApiService(repository, covids);
        }

        public IApiRepository GetApiRepository()
        {
            return _apiRepository;
        }

        public ICovidRepository GetCovidRepository()
        {
            return _covidRepository;
        }

        public async Task UpdateAsync()
        {
            await Task.Run(() => { });
        }

        public async Task AutoRunAsync()
        {
            await Task.Run(() => { });
        }
    }
}
