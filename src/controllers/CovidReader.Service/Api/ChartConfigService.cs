using CovidReader.Core.Service;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class ChartConfigService : IChartConfigService
    {
        private IChartConfigRepository _repository;

        public ChartConfigService(IChartConfigRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            }
            _repository = repository;

        }

        /// <summary>
        /// 指定外部データをリポジトリにインポート
        /// </summary>
        /// <param name="items">外部データ</param>
        /// <returns></returns>
        public async Task PostAsync(IEnumerable<ChartConfig> items)
        {
            await _repository.PostAsync(items);
        }

        public async Task<IEnumerable<ChartConfig>> GetAsync()
        {
            return await _repository.GetAsync();
        }


        public async Task CreateAsync()
        {
            if ((await _repository.GetAsync()).Count() == 0)
            {
                List<ChartConfig> result = new List<ChartConfig>();
                var date = DateTime.MinValue;

                result.Add(new ChartConfig
                {
                    Index = 0,
                    Date = date.ToString(),
                    Name = "Death",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,0,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 1,
                    Date = date.AddSeconds(1).ToString(),
                    Name = "Hospitalization",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,255,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 2,
                    Date = date.AddSeconds(2).ToString(),
                    Name = "Positive",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,0,255,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 3,
                    Date = date.AddSeconds(3).ToString(),
                    Name = "Recovery",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,128,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 4,
                    Date = date.AddSeconds(4).ToString(),
                    Name = "Severe",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,128,128,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 5,
                    Date = date.AddSeconds(5).ToString(),
                    Name = "Test",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,0,128,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Index = 6,
                    Date = date.AddSeconds(6).ToString(),
                    Name = "NationalTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,128,128,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Index = 7,
                    Date = date.AddSeconds(7).ToString(),
                    Name = "QuarantineTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,255,0,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Index = 8,
                    Date = date.AddSeconds(8).ToString(),
                    Name = "CareCenterTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,255,255,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Index = 9,
                    Date = date.AddSeconds(9).ToString(),
                    Name = "CivilCenterTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,0,255,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Index = 10,
                    Date = date.AddSeconds(10).ToString(),
                    Name = "CollegeTestNumber",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,128,0,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Index = 11,
                    Date = date.AddSeconds(11).ToString(),
                    Name = "MedicalTestNumber",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,255,128,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                await _repository.PostAsync(result);
            }
        }

    }
}
