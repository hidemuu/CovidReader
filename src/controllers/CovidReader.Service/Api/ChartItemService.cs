using CovidReader.Models;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using CovidReader.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class ChartItemService : IChartItemService
    {
        private IChartItemRepository _repository;

        public ChartItemService(IChartItemRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            }
            _repository = repository;
        }

        /// <summary>
        /// 指定外部データをリポジトリにインポート
        /// </summary>
        /// <param name="imports">外部データ</param>
        /// <returns></returns>
        public async Task PostAsync(IEnumerable<ChartItem> items)
        {
            await _repository.PostAsync(items);
        }

        public async Task<IEnumerable<ChartItem>> GetAsync()
        {
            return await _repository.GetAsync();
        }


        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task CreateAsync(IEnumerable<Infection> infections)
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
            
            Console.WriteLine("Exporting...");
            await _repository.PostAsync(result);
        }

    }
}
