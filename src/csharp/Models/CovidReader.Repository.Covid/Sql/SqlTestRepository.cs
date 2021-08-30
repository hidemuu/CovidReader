using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlTestRepository : SqlCovidRepositoryBase<Test>, ITestRepository
    {
        //private readonly CovidDbContext _db;

        public SqlTestRepository(CovidDbContext db) : base(db, db.Tests)
        {
            
        }

        //public async Task<IEnumerable<Test>> GetAsync()
        //{
        //    return await _db.Tests
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
