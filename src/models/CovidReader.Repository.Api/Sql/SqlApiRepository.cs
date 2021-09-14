using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlApiRepository : IApiRepository
    {
        private readonly DbContextOptions<ApiDbContext> _dbOptions;
        private readonly ApiDbContext _db;

        public SqlApiRepository(DbContextOptionsBuilder<ApiDbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new ApiDbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
            _db = new ApiDbContext(_dbOptions);
        }

        

        public IVirusRepository Viruses => new SqlVirusRepository(_db);

        public IInfectionRepository Infections => new SqlInfectionRepository(_db);

        public IViralTestRepository ViralTests => new SqlViralTestRepository(_db);

        public IInfectionTotalRepository InfectionTotals => new SqlInfectionTotalRepository(_db);

        public IViralTestTotalRepository ViralTestTotals => new SqlViralTestTotalRepository(_db);

        public IChartItemRepository ChartItems => new SqlChartItemRepository(_db);

        public IChartConfigRepository ChartConfigs => new SqlChartConfigRepository(_db);
    }
}
