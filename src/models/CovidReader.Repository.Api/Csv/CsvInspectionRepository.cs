using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvInspectionRepository : CsvApiRepositoryBase<Inspection>, IInspectionRepository
    {
        public CsvInspectionRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
