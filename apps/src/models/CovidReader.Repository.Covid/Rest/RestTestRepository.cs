using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestTestRepository : RestCovidRepositoryBase<Test>, ITestRepository
    {


        public RestTestRepository(string url, string key) : base(url, key, "test-cases")
        {
            
        }


    }
}
