using CovidReader.Models;
using CovidReader.Models.Covid19;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class Covid19Service : ICovid19Service
    {
        private readonly ICovid19Repository _repository;
        private readonly ICovid19Repository _mapper;

        public Covid19Service(ICovid19Repository repository, ICovid19Repository mapper)
        {
            if (repository == null) throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            if (mapper == null) throw new ArgumentNullException("mapper", "A valid repository must be supplied.");
            _repository = repository;
            _mapper = mapper;
        }

        public async Task MapperToRepositoryAsync()
        {
            await PostAsync(await _mapper.Deathes.GetAsync(), await _mapper.Hospitalizations.GetAsync(), await _mapper.Positives.GetAsync(), await _mapper.Recoveries.GetAsync(), await _mapper.Severes.GetAsync(), await _mapper.Tests.GetAsync(), await _mapper.TestDetails.GetAsync());
        }

        public async Task PostAsync(IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests, IEnumerable<TestDetail> testDetails)
        {
            
            var lineitems = new List<CovidLineItem>();
            foreach (var item in deaths)
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

            await _repository.Deathes.PostAsync(deaths);
            await _repository.Hospitalizations.PostAsync(hospitalizations);
            await _repository.Positives.PostAsync(positives);
            await _repository.Recoveries.PostAsync(recoveries);
            await _repository.Tests.PostAsync(tests);
            await _repository.TestDetails.PostAsync(testDetails);
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
            else if (typeof(T) == typeof(Hospitalization))
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
            else if (typeof(T) == typeof(Severe))
            {
                items = (IEnumerable<T>)await _repository.Severes.GetAsync();
                result = Severe.GetHeader();
            }
            else if (typeof(T) == typeof(Test))
            {
                items = (IEnumerable<T>)await _repository.Tests.GetAsync();
                result = Test.GetHeader();
            }
            else if (typeof(T) == typeof(TestDetail))
            {
                items = (IEnumerable<T>)await _repository.TestDetails.GetAsync();
                result = TestDetail.GetHeader();
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



    }
}
