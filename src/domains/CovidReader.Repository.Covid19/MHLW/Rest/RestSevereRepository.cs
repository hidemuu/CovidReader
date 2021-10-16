using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestSevereRepository : RestCovid19RepositoryBase<Severe>, ISevereRepository
    {


        public RestSevereRepository(string url, string key) : base(url, key, "severe-cases")
        {
            
        }

    }
}
