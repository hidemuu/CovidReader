using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public interface IAppController
    {
        Task UpdateAsync();
        Task AutoRunAsync();
    }
}
