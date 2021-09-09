using CovidReader.Models.Covid19.MHLW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlDeathRepository : SqlCovidRepositoryBase<Death>, IDeathRepository
    {

        public SqlDeathRepository(CovidDbContext db) : base(db, db.Deathes) { }

        

    }
}
