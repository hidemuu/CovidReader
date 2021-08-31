using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestTestDetailRepository : RestCovidRepositoryBase<TestDetail>, ITestDetailRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "test-details";

        public RestTestDetailRepository(string url, string key) : base(url, key, "test-details")
        {
            
        }

        //public async Task<IEnumerable<TestDetail>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<TestDetail>>(_root + _key);
    }
}
