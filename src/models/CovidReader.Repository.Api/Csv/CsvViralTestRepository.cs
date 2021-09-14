using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvViralTestRepository : CsvApiRepositoryBase<ViralTest>, IViralTestRepository
    {
        public CsvViralTestRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
