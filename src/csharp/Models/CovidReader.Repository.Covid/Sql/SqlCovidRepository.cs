using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Sql
{
    public class SqlCovidRepository : ICovidRepository
    {
        private readonly DbContextOptions<CovidDbContext> _dbOptions;

        public SqlCovidRepository(DbContextOptionsBuilder<CovidDbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new CovidDbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IDeathRepository Deathes => new SqlDeathRepository(
            new CovidDbContext(_dbOptions));

        public IHospitalizationRepository Hospitalizations => new SqlHospitalizationRepository(
            new CovidDbContext(_dbOptions));

        public IPositiveRepository Positives => new SqlPositiveRepository(
            new CovidDbContext(_dbOptions));

        public IRecoveryRepository Recoveries => new SqlRecoveryRepository(
            new CovidDbContext(_dbOptions));

        public ISevereRepository Severes => new SqlSevereRepository(
            new CovidDbContext(_dbOptions));

        public ITestRepository Tests => new SqlTestRepository(
            new CovidDbContext(_dbOptions));

        public ITestDetailRepository TestDetails => new SqlTestDetailRepository(
            new CovidDbContext(_dbOptions));
    }
}
