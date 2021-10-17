using CovidReader.Models;
using CovidReader.Models.Covid19;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Covid19
{
    /// <summary>
    /// Covid19 APIデータアクセスサービス実装クラス
    /// </summary>
    public class Covid19Service : ICovid19Service
    {
        private readonly ICovid19Repository _repository;
        private readonly ICovid19Mapper _mapper;

        /// <summary>
        /// コンストラクタ
        /// リポジトリとマッパーを注入
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public Covid19Service(ICovid19Repository repository, ICovid19Mapper mapper)
        {
            if (repository == null) throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            if (mapper == null) throw new ArgumentNullException("mapper", "A valid repository must be supplied.");
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// マッパーデータをリポジトリに全反映
        /// </summary>
        /// <returns></returns>
        public async Task MapperToRepositoryAsync()
        {
            await PostAsync(await _mapper.Deathes.GetAsync(), await _mapper.Hospitalizations.GetAsync(), await _mapper.Positives.GetAsync(), await _mapper.Recoveries.GetAsync(), await _mapper.Severes.GetAsync(), await _mapper.Tests.GetAsync(), await _mapper.TestDetails.GetAsync());
        }

        /// <summary>
        /// リポジトリにデータを登録
        /// </summary>
        /// <param name="deaths">死亡者数</param>
        /// <param name="hospitalizations">入院治療者数</param>
        /// <param name="positives">陽性者数</param>
        /// <param name="recoveries">治癒者数</param>
        /// <param name="severes">重傷者数</param>
        /// <param name="tests">検査件数</param>
        /// <param name="testDetails">検査詳細</param>
        /// <returns></returns>
        public async Task PostAsync(IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests, IEnumerable<TestDetail> testDetails)
        {
            
            var lineitems = new List<Covid19LineItem>();
            foreach (var item in deaths)
            {
                if(!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
                }
            }
            foreach (var item in hospitalizations)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
                }
            }
            foreach (var item in positives)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
                }
            }
            foreach (var item in recoveries)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
                }
            }
            foreach (var item in tests)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
                }
            }
            foreach (var item in testDetails)
            {
                if (!lineitems.Exists(x => x.Date == item.Date))
                {
                    lineitems.Add(new Covid19LineItem { Date = item.Date });
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync<T>() where T : Covid19DbObject
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
            else if (typeof(T) == typeof(Covid19LineItem))
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
