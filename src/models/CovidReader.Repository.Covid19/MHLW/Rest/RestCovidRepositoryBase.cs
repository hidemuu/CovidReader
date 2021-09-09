using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public abstract class RestCovidRepositoryBase<T>
    {
        private readonly HttpHelper _http;
        private readonly string _key;
        private readonly string _root;

        public RestCovidRepositoryBase(string url, string key, string root)
        {
            _http = new HttpHelper(url);
            _key = "?apikey=" + key;
            _root = root;
        }

        public async Task<IEnumerable<T>> GetAsync() =>
            await _http.GetAsync<IEnumerable<T>>(_root + _key);

        public async Task<T> GetAsync(string date) =>
           await _http.GetAsync<T>(_root + $"/{date}" + _key);

        public async Task PostAsync(T item) =>
            await _http.PostAsync<T, T>(_root + _key, item);

        public Task PostAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string date) =>
            await _http.DeleteAsync(_root + _key, date);

    }
}
