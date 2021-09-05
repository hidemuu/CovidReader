using CovidReader.Models.Covid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlTestDetailRepository : SqlCovidRepositoryBase<TestDetail>, ITestDetailRepository
    {

        public SqlTestDetailRepository(CovidDbContext db) : base(db, db.TestDetails) { }

    }
}
