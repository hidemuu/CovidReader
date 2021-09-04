using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlSevereRepository : SqlCovidRepositoryBase<Severe>, ISevereRepository
    {
        //private readonly CovidDbContext _db;

        public SqlSevereRepository(CovidDbContext db) : base(db, db.Severes)
        {
            
        }

        //public async Task<IEnumerable<Severe>> GetAsync()
        //{
        //    return await _db.Severes
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
