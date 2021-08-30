using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestTestRepository : RestCovidRepositoryBase<Test>, ITestRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "test-cases";

        public RestTestRepository(string url, string key) : base(url, key, "test-cases")
        {
            
        }

        //public async Task<IEnumerable<Test>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Test>>(_root + _key);

        //public async Task<Test> GetAsync(string date) =>
        //   await _http.GetAsync<Test>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Test test) =>
        //    await _http.PostAsync<Test, Test>(_root + _key, test);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);
    }
}
