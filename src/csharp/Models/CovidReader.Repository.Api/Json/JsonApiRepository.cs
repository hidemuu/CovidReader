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

        public IVirusRepository Viruses =>
            new JsonVirusRepository(_path + @"virus.json", _encode);

        public IChartItemRepository ChartItems =>
            new JsonChartItemRepository(_path + @"chart_item.json", _encode);

        public IChartConfigRepository ChartConfigs =>
            new JsonChartConfigRepository(_path + @"chart_config.json", _encode);

    }
}
