using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class ChartConfigService : IChartConfigService
    {
        private IChartConfigRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ChartConfig>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CreateAsync()
        {
            if ((await _repository.GetAsync()).Count() == 0)
            {
                List<ChartConfig> result = new List<ChartConfig>();
                var date = DateTime.MinValue;

                result.Add(new ChartConfig
                {
                    Name = "Death",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,0,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "Hospitalization",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,255,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "Positive",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,0,255,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "Recovery",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,128,0,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "Severe",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,128,128,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "Test",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,0,128,1)",
                    BorderWidth = 1,
                    Category = 0,
                });

                result.Add(new ChartConfig
                {
                    Name = "NationalTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(128,128,128,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Name = "QuarantineTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,255,0,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Name = "CareCenterTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(0,255,255,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Name = "CivilCenterTest",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,0,255,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
                    Name = "CollegeTestNumber",
                    ChartType = "line",
                    BackgroundColor = "rgba(0, 0, 0, 0)",
                    BorderColor = "rgba(255,128,0,1)",
                    BorderWidth = 1,
                    Category = 1,
                });

                result.Add(new ChartConfig
                {
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
