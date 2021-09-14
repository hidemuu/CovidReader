using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvInfectionRepository : CsvApiRepositoryBase<Infection>, IInfectionRepository
    {
        public CsvInfectionRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
