using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestDeathRepository : RestCovidRepositoryBase<Death>, IDeathRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "death-cases";

        public RestDeathRepository(string url, string key) : base(url, key, "death-cases")
        {
            
        }

        //public async Task<IEnumerable<Death>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Death>>(_root + _key);

        //public async Task<Death> GetAsync(string date) =>
        //   await _http.GetAsync<Death>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Death death) =>
        //    await _http.PostAsync<Death, Death>(_root + _key, death);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);

    }
}
