using CovidReader.Models;
using CovidReader.Models.Covid;
using CovidReader.Repository.Covid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Plugins.DataAccesses
{
    public class CovidRepositoryHelper
    {
        private ICovidRepository _repository;

        public CovidRepositoryHelper(ICovidRepository repository)
        {
            _repository = repository;
        }

        public ICovidRepository GetRepository()
        {
            return _repository;
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
            else if (typeof(T) == typeof(TestDetail))
            {
                items = (IEnumerable<T>)await _repository.TestDetails.GetAsync();
                result = Test.GetHeader();
            }
            else if (typeof(T) == typeof(CovidLineItem))
            {
                items = (IEnumerable<T>)await _repository.CovidLineItems.GetAsync();
                result = Test.GetHeader();
            }
            else
            {
                Console.WriteLine("登録されていないパラメータです");
                return null;
            }
            
            result += Formats.NewLine;
            var query = items.OrderByDescending(x => DateTime.Parse(x.Date));
            foreach (var item in query)
            {
                result += item.ToString() + Formats.NewLine;
            }
            Console.WriteLine(result);
            return items;
        }

        public async Task ImportAsync(ICovidRepository imports)
        {
            var deathes = await imports.Deathes.GetAsync();
            var hospitalizations = await imports.Hospitalizations.GetAsync();
            var positives = await  imports.Positives.GetAsync();
            var recoveries = await imports.Recoveries.GetAsync();
            //var severes = await _covid.GetAsync<Severe>();
            var testDetails = await imports.TestDetails.GetAsync();
            var tests = await imports.Tests.GetAsync();

            var lineitems = new List<CovidLineItem>();
            foreach (var item in deathes)
            {
                if(!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }
            foreach (var item in hospitalizations)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }
            foreach (var item in positives)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }
            foreach (var item in recoveries)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }
            foreach (var item in tests)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }
            foreach (var item in testDetails)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new CovidLineItem { Date = item.Date });
                }
            }

            await _repository.CovidLineItems.PostAsync(lineitems);

            await _repository.Deathes.PostAsync(deathes);
            await _repository.Hospitalizations.PostAsync(hospitalizations);
            await _repository.Positives.PostAsync(positives);
            await _repository.Recoveries.PostAsync(recoveries);
            await _repository.Tests.PostAsync(tests);
            await _repository.TestDetails.PostAsync(testDetails);
        }

        public async Task ExportAsync(ICovidRepository exports)
        {
            await exports.Deathes.PostAsync(await _repository.Deathes.GetAsync());
            await exports.Hospitalizations.PostAsync(await _repository.Hospitalizations.GetAsync());
            await exports.Positives.PostAsync(await _repository.Positives.GetAsync());
            await exports.Recoveries.PostAsync(await _repository.Recoveries.GetAsync());
            await exports.Tests.PostAsync(await _repository.Tests.GetAsync());
            await exports.TestDetails.PostAsync(await _repository.TestDetails.GetAsync());
        }

    }
}
