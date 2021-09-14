using CovidReader.Models.Covid19;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.InMemory
{
    public class InMemoryCovidRepositoryBase<T> where T : CovidDbObject
    {
        private IList<T> _items;

        public InMemoryCovidRepositoryBase()
        {
            if (_items == null) _items = new List<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => _items);
        }

        public async Task<T> GetAsync(string date)
        {
            return await Task.Run(() => _items.FirstOrDefault(x => x.Date == date));
        }

        public async Task PostAsync(T item)
        {
            await Task.Run(() => _items.Add(item));
        }

        public async Task PostAsync(IEnumerable<T> items) 
        {
            
            await Task.Run(() => 
            {
                foreach(var item in items)
                {
                    _items.Add(item);
                }  
            });
        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }

    }
}
