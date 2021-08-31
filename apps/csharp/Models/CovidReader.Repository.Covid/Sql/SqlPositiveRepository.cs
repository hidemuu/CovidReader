using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlPositiveRepository : SqlCovidRepositoryBase<Positive>, IPositiveRepository
    {
        //private readonly CovidDbContext _db;

        public SqlPositiveRepository(CovidDbContext db) : base(db, db.Positives)
        {
            //_db = db;
        }

        //public async Task<IEnumerable<Positive>> GetAsync()
        //{
        //    return await _db.Positives
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
