using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlHospitalizationRepository : SqlCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {
        //private readonly CovidDbContext _db;

        public SqlHospitalizationRepository(CovidDbContext db) : base(db, db.Hospitalizations)
        {
            
        }

        //public async Task<IEnumerable<Hospitalization>> GetAsync()
        //{
        //    return await _db.Hospitalizations
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
