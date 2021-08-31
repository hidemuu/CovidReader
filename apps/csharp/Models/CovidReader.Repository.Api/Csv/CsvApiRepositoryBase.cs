using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvApiRepositoryBase<T> where T : DbObject
    {
        private readonly CsvFileHelper _csv;

        public CsvApiRepositoryBase(string fileName, string encode = "utf-8")
        {
            _csv = new CsvFileHelper(fileName, encode);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => _csv.Read<T>());
        }

        public async Task<T> GetAsync(string date)
        {
            var items = await Task.Run(() => _csv.Read<T>());
            return items.FirstOrDefault(x => x.Date == date);
        }


        public async Task PostAsync(T item)
        {
            var list = new List<T>();
            list.Add(item);
            await Task.Run(() => _csv.Write<T>(list));
        }

        public async Task PostAsync(IEnumerable<T> items)
        {
            await Task.Run(async () =>
            {
                foreach (var item in items)
                {
                    await PostAsync(item);
                }
            });
        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
