using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvChartConfigRepository : CsvApiRepositoryBase<ChartConfig>, IChartConfigRepository
    {
        public CsvChartConfigRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
