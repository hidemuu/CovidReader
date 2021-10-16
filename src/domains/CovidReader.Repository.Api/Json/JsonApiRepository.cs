using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Json
{
    public class JsonApiRepository : IApiRepository
    {
        private readonly string _path;
        private readonly string _encode;

        public JsonApiRepository(string path, string encode = "utf-8")
        {
            _path = Urls.RootPath + path + @"\";
            _encode = encode;
        }

        public IInfectionRepository Infections =>
            new JsonInfectionRepository(_path + @"infection.json", _encode);

        public IInspectionRepository Inspections =>
            new JsonInspectionRepository(_path + @"viral_test.json", _encode);

        public IChartItemRepository ChartItems =>
            new JsonChartItemRepository(_path + @"chart_item.json", _encode);

        public IChartConfigRepository ChartConfigs =>
            new JsonChartConfigRepository(_path + @"chart_config.json", _encode);

    }
}
