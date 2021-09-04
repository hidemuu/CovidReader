using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestSevereRepository : RestCovidRepositoryBase<Severe>, ISevereRepository
    {


        public RestSevereRepository(string url, string key) : base(url, key, "severe-cases")
        {
            
        }

    }
}
