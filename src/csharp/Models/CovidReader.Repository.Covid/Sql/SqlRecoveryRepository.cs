using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlRecoveryRepository : SqlCovidRepositoryBase<Recovery>, IRecoveryRepository
    {
        //private readonly CovidDbContext _db;

        public SqlRecoveryRepository(CovidDbContext db) : base(db, db.Recoveries)
        {
            //_db = db;
        }

        //public async Task<IEnumerable<Recovery>> GetAsync()
        //{
        //    return await _db.Recoveries
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
