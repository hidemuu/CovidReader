using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestPositiveRepository : RestCovidRepositoryBase<Positive>, IPositiveRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "positive-cases";

        public RestPositiveRepository(string url, string key) : base(url, key, "positive-cases")
        {
    
        }

        //public async Task<IEnumerable<Positive>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Positive>>(_root + _key);

        //public async Task<Positive> GetAsync(string date) =>
        //   await _http.GetAsync<Positive>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Positive positive) =>
        //    await _http.PostAsync<Positive, Positive>(_root + _key, positive);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);
    }
}
