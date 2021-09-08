using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestTestDetailRepository : RestCovidRepositoryBase<TestDetail>, ITestDetailRepository
    {


        public RestTestDetailRepository(string url, string key) : base(url, key, "test-details")
        {
            
        }

    }
}
