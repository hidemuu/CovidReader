﻿using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api.Json
{
    public abstract class JsonApiDailyRepositoryBase<T> where T : DailyDbObject
    {
        private readonly JsonFileHelper _json;

        public JsonApiDailyRepositoryBase(string fileName, string encode = "utf-8")
        {
            _json = new JsonFileHelper(fileName, encode);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => _json.Read<IEnumerable<T>>());
        }

        public async Task<T> GetAsync(string date)
        {
            var items = await GetAsync();
            return items.FirstOrDefault(x => x.Date == date);
        }


        public async Task PostAsync(T item)
        {
            await Task.Run(() => _json.Write<T>(item));
        }

        public async Task PostAsync(IEnumerable<T> items)
        {
            await Task.Run(() => _json.Write<IEnumerable<T>>(items));
            
        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
