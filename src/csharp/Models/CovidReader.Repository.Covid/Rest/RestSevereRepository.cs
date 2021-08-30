using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestSevereRepository : RestCovidRepositoryBase<Severe>, ISevereRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "severe-cases";

        public RestSevereRepository(string url, string key) : base(url, key, "severe-cases")
        {
            
        }

        //public async Task<IEnumerable<Severe>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Severe>>(_root + _key);

        //public async Task<Severe> GetAsync(string date) =>
        //   await _http.GetAsync<Severe>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Severe severe) =>
        //    await _http.PostAsync<Severe, Severe>(_root + _key, severe);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);
    }
}
