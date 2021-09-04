using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestDeathRepository : RestCovidRepositoryBase<Death>, IDeathRepository
    {

        public RestDeathRepository(string url, string key) : base(url, key, "death-cases")
        {
            
        }


    }
}
