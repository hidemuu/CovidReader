using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlDeathRepository : SqlCovidRepositoryBase<Death>, IDeathRepository
    {
        //private readonly CovidDbContext _db;

        public SqlDeathRepository(CovidDbContext db) : base(db, db.Deathes)
        {
            
        }

        //public async Task<IEnumerable<Death>> GetAsync()
        //{
        //    return await _db.Deathes
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        //public async Task<Death> GetAsync(string date)
        //{
        //    return await _db.Deathes
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.Date == date);
        //}


        //public async Task PostAsync(Death death)
        //{
        //    var current = await _db.Deathes.FirstOrDefaultAsync(_m => _m.Date == death.Date);
        //    if (null == current)
        //    {
        //        _db.Deathes.Add(death);
        //    }
        //    else
        //    {
        //        _db.Entry(current).CurrentValues.SetValues(death);
        //    }
        //    await _db.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(string date)
        //{
        //    var item = await _db.Deathes.FirstOrDefaultAsync(_m => _m.Date == date);
        //    if (null != item)
        //    {
        //        _db.Deathes.Remove(item);
        //        await _db.SaveChangesAsync();
        //    }
        //}

    }
}
