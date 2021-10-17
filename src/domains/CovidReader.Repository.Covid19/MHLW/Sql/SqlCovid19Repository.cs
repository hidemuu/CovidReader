using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Sql
{
    public class SqlCovid19Repository : ICovid19Repository, ICovid19Mapper
    {
        private readonly DbContextOptions<Covid19DbContext> _dbOptions;

        public SqlCovid19Repository(DbContextOptionsBuilder<Covid19DbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new Covid19DbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IDeathRepository Deathes => new SqlDeathRepository(
            new Covid19DbContext(_dbOptions));

        public IHospitalizationRepository Hospitalizations => new SqlHospitalizationRepository(
            new Covid19DbContext(_dbOptions));

        public IPositiveRepository Positives => new SqlPositiveRepository(
            new Covid19DbContext(_dbOptions));

        public IRecoveryRepository Recoveries => new SqlRecoveryRepository(
            new Covid19DbContext(_dbOptions));

        public ISevereRepository Severes => new SqlSevereRepository(
            new Covid19DbContext(_dbOptions));

        public ITestRepository Tests => new SqlTestRepository(
            new Covid19DbContext(_dbOptions));

        public ITestDetailRepository TestDetails => new SqlTestDetailRepository(
            new Covid19DbContext(_dbOptions));

        public ICovid19LineItemRepository CovidLineItems => new SqlCovid19LineItemRepository(
            new Covid19DbContext(_dbOptions));
    }
}
