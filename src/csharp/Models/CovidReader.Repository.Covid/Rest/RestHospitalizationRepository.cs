using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestHospitalizationRepository : RestCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {
        //private readonly HttpHelper _http;
        //private readonly string _key;
        //private readonly string _root = "hospitalization-cases";

        public RestHospitalizationRepository(string url, string key) : base(url, key, "hospitalization-cases")
        {
            
        }

        //public async Task<IEnumerable<Hospitalization>> GetAsync() =>
        //    await _http.GetAsync<IEnumerable<Hospitalization>>(_root + _key);

        //public async Task<Hospitalization> GetAsync(string date) =>
        //   await _http.GetAsync<Hospitalization>(_root + $"/{date}" + _key);

        //public async Task PostAsync(Hospitalization hospitalization) =>
        //    await _http.PostAsync<Hospitalization, Hospitalization>(_root + _key, hospitalization);

        //public async Task DeleteAsync(string date) =>
        //    await _http.DeleteAsync(_root + _key, date);
    }
}
