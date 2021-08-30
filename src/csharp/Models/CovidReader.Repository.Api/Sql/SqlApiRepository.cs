using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Sql
{
    public class SqlApiRepository : IApiRepository
    {
        private readonly DbContextOptions<ApiDbContext> _dbOptions;

        public SqlApiRepository(DbContextOptionsBuilder<ApiDbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new ApiDbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IVirusRepository Viruses => new SqlVirusRepository(
            new ApiDbContext(_dbOptions));

        public IChartItemRepository ChartItems => new SqlChartItemRepository(
            new ApiDbContext(_dbOptions));

        public IChartConfigRepository ChartConfigs => new SqlChartConfigRepository(
            new ApiDbContext(_dbOptions));
    }
}
