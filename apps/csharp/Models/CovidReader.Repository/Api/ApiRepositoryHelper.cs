using CovidReader.Models;
using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public class ApiRepositoryHelper
    {
        private IApiRepository _repository;

        public ApiRepositoryHelper(IApiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : DbObject
        {
            var result = "";
            IEnumerable<T> items;
            if (typeof(T) == typeof(Virus))
            {
                items = (IEnumerable<T>)await _repository.Viruses.GetAsync();
                result = Virus.GetHeader();
            }
            else if (typeof(T) == typeof(ChartItem))
            {
                items = (IEnumerable<T>)await _repository.ChartItems.GetAsync();
                result = ChartItem.GetHeader();
            }
            else
            {
                Console.WriteLine("登録されていないパラメータです");
                return null;
            }

            //コンソール表示
            result += Formats.NewLine;
            var query = items.OrderBy(x => DateTime.Parse(x.Date));
            foreach (var item in query)
            {
                result += item.ToString() + Formats.NewLine;
            }
            Console.WriteLine(result);

            return items;
        }

        public async Task ImportAsync(IApiRepository imports)
        {
            await _repository.Viruses.PostAsync(await imports.Viruses.GetAsync());
            await _repository.ChartItems.PostAsync(await imports.ChartItems.GetAsync());
            
        }

        public async Task ExportAsync(IApiRepository exports)
        {
            await exports.Viruses.PostAsync(await _repository.Viruses.GetAsync());
            await exports.ChartItems.PostAsync(await _repository.ChartItems.GetAsync());
        }

        public async Task ExportAsync(IApiRepository exports, IEnumerable<ChartItem> items)
        {
            await exports.ChartItems.PostAsync(items);
        }

        public async Task ExportAsync(IApiRepository exports, IEnumerable<ChartConfig> items)
        {
            await exports.ChartConfigs.PostAsync(items);
        }

        public async Task ExportAsync(IApiRepository exports, IEnumerable<Virus> items)
        {
            await exports.Viruses.PostAsync(items);
        }

    }
}
