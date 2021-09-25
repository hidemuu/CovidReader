using CovidReader.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api.Sql
{
    public abstract class SqlApiRepositoryBase<T> where T: DbObject
    {
        private readonly ApiDbContext _db;
        private readonly DbSet<T> _ts;

        public SqlApiRepositoryBase(ApiDbContext db, DbSet<T> ts)
        {
            _db = db;
            _ts = ts;

        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _ts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetAsync(string name)
        {
            return await _ts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Name == name);
        }


        public async Task PostAsync(T item)
        {
            var current = await _ts.FirstOrDefaultAsync(_m => _m.Id == item.Id);
            //var current = await _ts.Where(x => x.Name == item.Name).FirstOrDefaultAsync(_m => _m.Calc == item.Calc);
            if (null == current)
            {
                _ts.Add(item);
            }
            else
            {
                var value = item;
                value.Id = current.Id;
                _db.Entry(current).CurrentValues.SetValues(value);
            }

            await _db.SaveChangesAsync();
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

        public async Task DeleteAsync(string name)
        {
            var query = _ts.Where(x => x.Name == name);
            foreach (var q in query)
            {
                var item = await _ts.FirstOrDefaultAsync(_m => _m.Id == q.Id);
                if (null != item)
                {
                    _ts.Remove(item);
                    await _db.SaveChangesAsync();
                }
            }

        }
    }
}
