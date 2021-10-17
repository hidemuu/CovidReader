using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Csv
{
    public class CsvApiRepository : IApiRepository, IApiMapper
    {
        private readonly string _path;
        private readonly string _encode;

        public CsvApiRepository(string path, string encode = "utf-8")
        {
            _path = Urls.RootPath + path + @"\";
            _encode = encode;
        }


        public IInfectionRepository Infections =>
            new CsvInfectionRepository(_path + @"infections.csv", _encode);

        public IInspectionRepository Inspections =>
            new CsvInspectionRepository(_path + @"viral_test.csv", _encode);


        public IChartItemRepository ChartItems =>
            new CsvChartItemRepository(_path + @"chart_item.csv", _encode);

        public IChartConfigRepository ChartConfigs =>
            new CsvChartConfigRepository(_path + @"chart_config.csv", _encode);

    }
}
