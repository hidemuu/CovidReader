using CovidReader.Utilities;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Api
{
    /// <summary>
    /// 感染データアクセスサービス実装クラス
    /// </summary>
    public class InfectionService : IInfectionService
    {
        private IInfectionRepository _repository;

        /// <summary>
        /// コンストラクタ
        /// 感染データリポジトリを注入
        /// </summary>
        /// <param name="repository"></param>
        public InfectionService(IInfectionRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "A valid repository must be supplied.");
            }
            _repository = repository;
        }

        /// <summary>
        /// リポジトリを更新・追加
        /// </summary>
        /// <param name="items">外部データ</param>
        /// <returns></returns>
        public async Task PostAsync(IEnumerable<Infection> items)
        {
            await _repository.PostAsync(items);
        }

        /// <summary>
        /// リポジトリから取得
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Infection>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        /// <summary>
        /// Covid19 APIから取得した各感染データで、アプリケーションAPIの感染データベースを生成（全更新）
        /// </summary>
        /// <param name="dates">日付</param>
        /// <param name="deaths">死亡者数</param>
        /// <param name="hospitalizations">入院治療者数</param>
        /// <param name="positives">陽性者数</param>
        /// <param name="recoveries">治癒者数</param>
        /// <param name="severes">重傷者数</param>
        /// <param name="tests">検査件数</param>
        /// <returns></returns>
        public async Task CreateAsync(IList<string> dates, IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests)
        {
            
            var dailys = await CreateDailyAsync(dates, deaths, hospitalizations, positives, recoveries, severes, tests);
            var totals = await CreateTotalAsync(dailys.ToList(), dates);

            await _repository.PostAsync(dailys);
            await _repository.PostAsync(totals);

        }

        #region private

        private async Task<IEnumerable<Infection>> CreateDailyAsync(IList<string> dates, IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests)
        {
            var items = new List<Infection>();
            var count = 0;

            //感染データ取得
            await Task.Run(() => 
            {
                foreach (var date in dates)
                {
                    items.Add(new Infection
                    {
                        Index = count,
                        Date = date,
                        CountryName = "Japan",
                        Calc = "daily",
                        DeathNumber = CovidDbObjectToInt(deaths.FirstOrDefault(x => x.Date == date)),
                        CureNumber = CovidDbObjectToInt(hospitalizations.FirstOrDefault(x => x.Date == date)),
                        PatientNumber = CovidDbObjectToInt(positives.FirstOrDefault(x => x.Date == date)),
                        RecoveryNumber = CovidDbObjectToInt(recoveries.FirstOrDefault(x => x.Date == date)),
                        SevereNumber = CovidDbObjectToInt(severes.FirstOrDefault(x => x.Date == date)),
                        TestNumber = CovidDbObjectToInt(tests.FirstOrDefault(x => x.Date == date)),
                    });


                    count++;
                }
            });
            
            //一部累計データがあるので分解
            var deathNumbers = (int[])DataConverter.SumToUnit(items.Select(x => x.DeathNumber).ToArray());
            var recoveryNumbers = (int[])DataConverter.SumToUnit(items.Select(x => x.RecoveryNumber).ToArray());
            
            count = 0;
            var result = new List<Infection>();

            await Task.Run(() => 
            {
                foreach (var item in items)
                {
                    var tmp = item;
                    tmp.DeathNumber = deathNumbers[count];
                    tmp.RecoveryNumber = recoveryNumbers[count];
                    result.Add(tmp);
                    count++;
                }

            });
            
            return result;
        }

        private async Task<IEnumerable<Infection>> CreateTotalAsync(IList<Infection> infections, IList<string> dates)
        {
            
            var deathSums = (int[])DataConverter.UnitToSum(infections.Select(x => x.DeathNumber).ToArray());
            var cureSums = (int[])DataConverter.UnitToSum(infections.Select(x => x.CureNumber).ToArray());
            var patientSums = (int[])DataConverter.UnitToSum(infections.Select(x => x.PatientNumber).ToArray());
            var recoverySums = (int[])DataConverter.UnitToSum(infections.Select(x => x.RecoveryNumber).ToArray());
            var severeSums = (int[])DataConverter.UnitToSum(infections.Select(x => x.SevereNumber).ToArray());
            var testSums = (int[])DataConverter.UnitToSum(infections.Select(x => x.TestNumber).ToArray());

            var result = new List<Infection>();
            
            await Task.Run(() => 
            {
                var count = 0;
                foreach (var date in dates)
                {
                    result.Add(new Infection
                    {
                        Index = count,
                        Date = date,
                        CountryName = "Japan",
                        Calc = "total",
                        DeathNumber = deathSums[count],
                        CureNumber = cureSums[count],
                        PatientNumber = patientSums[count],
                        RecoveryNumber = recoverySums[count],
                        SevereNumber = severeSums[count],
                        TestNumber = testSums[count],
                    });

                    count++;
                }
            });

            return result;
        }

        private static int CovidDbObjectToInt(Covid19DbObject obj)
        {
            if (obj != null)
            {
                return DataConverter.StringToInt(obj.Number, 0);
            }
            else
            {
                return 0;
            }
        }

        #endregion

    }
}
