using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvInfectionTotalRepository : CsvApiRepositoryBase<InfectionTotal>, IInfectionTotalRepository
    {
        public CsvInfectionTotalRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
