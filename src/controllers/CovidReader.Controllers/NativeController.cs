using CovidReader.Controllers.UseCases;
using CovidReader.Core;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class NativeController : ApiController, IAppController
    {
        private IApiRepository _apiRepository;
        private ICovid19Repository _covidRepository;

        public NativeController(IApiRepository api, ICovid19Repository covids) : base(api, covids)
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
