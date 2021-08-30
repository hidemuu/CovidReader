using CovidReader.Models;
using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class CovidRepositoryHelper
    {
        private ICovidRepository _repository;

        public CovidRepositoryHelper(ICovidRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : CovidDbObject
        {
            var result = "";
            IEnumerable<T> items;
            if (typeof(T) == typeof(Death))
            {
                items = (IEnumerable<T>)await _repository.Deathes.GetAsync();
                result = Death.GetHeader();
            }
            else if(typeof(T) == typeof(Hospitalization))
            {
                items = (IEnumerable<T>)await _repository.Hospitalizations.GetAsync(); 
                result = Hospitalization.GetHeader();
            }
            else if (typeof(T) == typeof(Positive))
            {
                items = (IEnumerable<T>)await _repository.Positives.GetAsync(); 
                result = Positive.GetHeader();
            }
            else if (typeof(T) == typeof(Recovery))
            {
                items = (IEnumerable<T>)await _repository.Recoveries.GetAsync();
                result = Recovery.GetHeader();
            }
            else if (typeof(T) == typeof(Test))
            {
                items = (IEnumerable<T>)await _repository.Tests.GetAsync();
                result = Test.GetHeader();
            }
            else
            {
                Console.WriteLine("登録されていないパラメータです");
                return null;
            }
            
            result += Formats.NewLine;
            var query = items.OrderByDescending(x => x.Date);
            foreach (var item in query)
            {
                result += item.ToString() + Formats.NewLine;
            }
            Console.WriteLine(result);
            return items;
        }

        public async Task ImportAsync(ICovidRepository imports)
        {
            await _repository.Deathes.PostAsync(await imports.Deathes.GetAsync());
            await _repository.Hospitalizations.PostAsync(await imports.Hospitalizations.GetAsync());
            await _repository.Positives.PostAsync(await imports.Positives.GetAsync());
            await _repository.Recoveries.PostAsync(await imports.Recoveries.GetAsync());
            await _repository.Tests.PostAsync(await imports.Tests.GetAsync());
        }

        public async Task ExportAsync(ICovidRepository exports)
        {
            await exports.Deathes.PostAsync(await _repository.Deathes.GetAsync());
            await exports.Hospitalizations.PostAsync(await _repository.Hospitalizations.GetAsync());
            await exports.Positives.PostAsync(await _repository.Positives.GetAsync());
            await exports.Recoveries.PostAsync(await _repository.Recoveries.GetAsync());
            await exports.Tests.PostAsync(await _repository.Tests.GetAsync());
        }

    }
}
