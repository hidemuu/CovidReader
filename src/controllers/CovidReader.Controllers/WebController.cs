using CovidReader.Controllers.UseCases;
using CovidReader.Core;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class WebController : ApiController, IAppController
    {

        private IApiRepository _apiRepository;
        private ICovid19Repository _covidRepository;

        public WebController(IApiRepository api, ICovid19Repository covids) : base(api, covids)
        {
            _apiRepository = api;
            _covidRepository = covids;
        }
        
        public async Task UpdateAsync()
        {
            await ImportAsync(CovidRepositoryUseCase.UseCsv());
            await CovidToApiAsync();
            await ToChartItemAsync();
        }

        
        public async Task AutoRunAsync()
        {
            await Task.Run(() => { });
        }
    }
}
