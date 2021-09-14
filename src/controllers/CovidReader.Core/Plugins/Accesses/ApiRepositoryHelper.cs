using CovidReader.Core.Plugins.Utilities;
using CovidReader.Models;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Plugins.Accesses
{
    public class ApiRepositoryHelper : IRepositoryHelper<IApiRepository>
    {
        private IApiRepository _repository;

        public ApiRepositoryHelper(IApiRepository repository)
        {
            _repository = repository;
        }

        public IApiRepository GetRepository()
        {
            return _repository;
        }


        
        /// <summary>
        /// 指定外部データをリポジトリにインポート
        /// </summary>
        /// <param name="imports">外部データ</param>
        /// <returns></returns>
        public async Task ImportAsync(IApiRepository imports)
        {
            await _repository.Viruses.PostAsync(await imports.Viruses.GetAsync());
            await _repository.ChartItems.PostAsync(await imports.ChartItems.GetAsync());
            await _repository.ChartConfigs.PostAsync(await imports.ChartConfigs.GetAsync());

        }

        /// <summary>
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(IApiRepository exports)
        {
            await exports.Viruses.PostAsync(await _repository.Viruses.GetAsync());
            await exports.ChartItems.PostAsync(await _repository.ChartItems.GetAsync());
            await exports.ChartConfigs.PostAsync(await _repository.ChartConfigs.GetAsync());
        }

        
        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task ToChartItemAsync()
        {

            var chartConfigs = GetChartConfigs();
            //var chartItems = GetChartItems(await _repository.Viruses.GetAsync());
            var chartItems = GetChartItems(await _repository.Infections.GetAsync());

            Console.WriteLine("Exporting...");
            if ((await _repository.ChartConfigs.GetAsync()).Count() == 0)
            {
                await _repository.ChartConfigs.PostAsync(chartConfigs);
            }
            await _repository.ChartItems.PostAsync(chartItems);
        }

        
        private static IEnumerable<ChartItem> GetChartItems(IEnumerable<Virus> viruses)
        {
            List<ChartItem> result = new List<ChartItem>();
            foreach (var item in viruses)
            {
                result.Add(new ChartItem
                {
                    Id = item.Id,
                    Date = item.Date,
                    Data = item.DeathNumber.ToString() + Formats.Delimiter +
                           item.HospitalizationNumber.ToString() + Formats.Delimiter +
                           item.PositiveNumber.ToString() + Formats.Delimiter +
                           item.RecoveryNumber.ToString() + Formats.Delimiter +
                           item.SevereNumber.ToString() + Formats.Delimiter +
                           item.TestNumber.ToString() + Formats.Delimiter +
                           item.NationalTestNumber.ToString() + Formats.Delimiter +
                           item.QuarantineTestNumber.ToString() + Formats.Delimiter +
                           item.CareCenterTestNumber.ToString() + Formats.Delimiter +
                           item.CivilCenterTestNumber.ToString() + Formats.Delimiter +
                           item.CollegeTestNumber.ToString() + Formats.Delimiter +
                           item.MedicalTestNumber.ToString(),
                });
            }
            return result;
        }

        private static IEnumerable<ChartItem> GetChartItems(IEnumerable<Infection> infections)
        {
            List<ChartItem> result = new List<ChartItem>();
            foreach (var item in infections)
            {
                result.Add(new ChartItem
                {
                    Id = item.Id,
                    Date = item.Date,
                    Data = item.DeathNumber.ToString() + Formats.Delimiter +
                           item.CureNumber.ToString() + Formats.Delimiter +
                           item.PatientNumber.ToString() + Formats.Delimiter +
                           item.RecoveryNumber.ToString() + Formats.Delimiter +
                           item.SevereNumber.ToString() + Formats.Delimiter +
                           item.TestNumber.ToString(),
                });
            }
            return result;
        }

        private static IEnumerable<ChartConfig> GetChartConfigs()
        {
            List<ChartConfig> result = new List<ChartConfig>();
            var date = DateTime.MinValue;

            result.Add(new ChartConfig
            {
                Id = 0,
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
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
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
                Id = 6,
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
                Id = 7,
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
                Id = 8,
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
                Id = 9,
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
                Id = 10,
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
                Id = 11,
                Date = date.AddSeconds(11).ToString(),
                Name = "MedicalTestNumber",
                ChartType = "line",
                BackgroundColor = "rgba(0, 0, 0, 0)",
                BorderColor = "rgba(0,255,128,1)",
                BorderWidth = 1,
                Category = 1,
            });

            return result;
        }

    }
}
