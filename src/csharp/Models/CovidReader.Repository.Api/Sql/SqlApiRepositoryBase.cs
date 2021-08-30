using CovidReader.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlApiRepositoryBase<T> where T : DbObject
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

        public async Task<T> GetAsync(string date)
        {
            return await _ts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Date == date);
        }


        public async Task PostAsync(T item)
        {
            var current = await _ts.FirstOrDefaultAsync(_m => _m.Date == item.Date);
            if (null == current)
            {
                _ts.Add(item);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(item);
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

        public async Task DeleteAsync(string date)
        {
            var item = await _ts.FirstOrDefaultAsync(_m => _m.Date == date);
            if (null != item)
            {
                _ts.Remove(item);
                await _db.SaveChangesAsync();
            }
        }

    }
}
