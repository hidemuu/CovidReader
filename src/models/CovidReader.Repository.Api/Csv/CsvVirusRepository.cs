using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvVirusRepository : CsvApiRepositoryBase<Virus>, IVirusRepository
    {
        public CsvVirusRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
