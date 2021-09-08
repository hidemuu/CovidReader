using CovidReader.Models;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Plugins.DataAccesses
{
    public class ApiRepositoryHelper
    {
        private IApiRepository _repository;

        public ApiRepositoryHelper(IApiRepository repository)
        {
            _repository = repository;
        }

        
        /// <summary>
        /// 指定DBテーブルデータを取得
        /// </summary>
        /// <typeparam name="T">DBテーブル構造クラス</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync<T>() where T : DbObject
        {
            var disp = "";
            IEnumerable<T> items;
            if (typeof(T) == typeof(Virus))
            {
                items = (IEnumerable<T>)await _repository.Viruses.GetAsync();
                disp = Virus.GetHeader();
            }
            else if (typeof(T) == typeof(ChartItem))
            {
                items = (IEnumerable<T>)await _repository.ChartItems.GetAsync();
                disp = ChartItem.GetHeader();
            }
            else if (typeof(T) == typeof(ChartConfig))
            {
                items = (IEnumerable<T>)await _repository.ChartConfigs.GetAsync();
                disp = ChartConfig.GetHeader();
            }
            else
            {
                Console.WriteLine("登録されていないパラメータです");
                return null;
            }

            //コンソール表示
            disp += Formats.NewLine;
            var query = items.OrderBy(x => DateTime.Parse(x.Date));
            foreach (var item in query)
            {
                disp += item.ToString() + Formats.NewLine;
            }
            Console.WriteLine(disp);

            return items;
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
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <param name="items">出力対象テーブル</param>
        /// <returns></returns>
        public async Task PostAsync(IApiRepository exports, IEnumerable<ChartItem> items)
        {
            await exports.ChartItems.PostAsync(items);
        }
        /// <summary>
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <param name="configs">出力対象テーブル</param>
        /// <returns></returns>
        public async Task PostAsync(IApiRepository exports, IEnumerable<ChartConfig> configs)
        {
            await exports.ChartConfigs.PostAsync(configs);
        }
        /// <summary>
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <param name="viruses">出力対象テーブル</param>
        /// <returns></returns>
        public async Task PostAsync(IApiRepository exports, IEnumerable<Virus> viruses)
        {
            await exports.Viruses.PostAsync(viruses);
        }

    }
}
