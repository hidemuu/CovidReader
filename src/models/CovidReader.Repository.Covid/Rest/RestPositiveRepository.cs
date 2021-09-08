using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestPositiveRepository : RestCovidRepositoryBase<Positive>, IPositiveRepository
    {


        public RestPositiveRepository(string url, string key) : base(url, key, "positive-cases")
        {
    
        }


    }
}
