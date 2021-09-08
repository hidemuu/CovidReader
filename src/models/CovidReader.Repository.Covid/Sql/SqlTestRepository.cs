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

        public SqlTestRepository(CovidDbContext db) : base(db, db.Tests) { }

    }
}
