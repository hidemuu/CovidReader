using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestRecoveryRepository : RestCovidRepositoryBase<Recovery>, IRecoveryRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "recovery-cases";

        public RestRecoveryRepository(string url, string key) : base(url, key, "recovery-cases")
        {
            
        }

        //public async Task<IEnumerable<Recovery>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Recovery>>(_root + _key);

        //public async Task<Recovery> GetAsync(string date) =>
        //   await _http.GetAsync<Recovery>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Recovery recovery) =>
        //    await _http.PostAsync<Recovery, Recovery>(_root + _key, recovery);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);
    }
}
