using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public interface IController
    {
        IApiRepository GetApiRepository();
        ICovidRepository GetCovidRepository();

        Task UpdateAsync();
        Task AutoRunAsync();
    }
}
