using CovidReader.Core.Utilities;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Services
{
    public class InfectionService : IRepositoryService<IInfectionRepository>
    {
        private IInfectionRepository _repository;

        public InfectionService(IInfectionRepository repository)
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
        public async Task ImportAsync(IInfectionRepository imports)
        {
            await _repository.PostAsync(await imports.GetAsync());
        }

        /// <summary>
        /// 指定外部データにリポジトリデータをエクスポート
        /// </summary>
        /// <param name="exports">出力先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(IInfectionRepository exports)
        {
            await exports.PostAsync(await _repository.GetAsync());
        }

        public async Task CreateAsync(ICovid19Repository covid19s)
        {
            
            var dates = await GetDatesAsync(covid19s);
            var dailys = await CreateDailyAsync(covid19s, dates);
            var totals = await CreateTotalAsync(dailys.ToList(), dates);

            await _repository.PostAsync(dailys);
            await _repository.PostAsync(totals);

        }

        public async Task<IEnumerable<Infection>> CreateDailyAsync(ICovid19Repository covid19s, IList<string> dates)
        {
            var items = new List<Infection>();
            var count = 0;
            
            //感染データ取得
            
            foreach (var date in dates)
            {
                items.Add(new Infection
                {
                    Index = count,
                    Date = date,
                    CountryName = "Japan",
                    Calc = "daily",
                    DeathNumber = CovidDbObjectToInt((await covid19s.Deathes.GetAsync()).FirstOrDefault(x => x.Date == date)),
                    CureNumber = CovidDbObjectToInt((await covid19s.Hospitalizations.GetAsync()).FirstOrDefault(x => x.Date == date)),
                    PatientNumber = CovidDbObjectToInt((await covid19s.Positives.GetAsync()).FirstOrDefault(x => x.Date == date)),
                    RecoveryNumber = CovidDbObjectToInt((await covid19s.Recoveries.GetAsync()).FirstOrDefault(x => x.Date == date)),
                    SevereNumber = CovidDbObjectToInt((await covid19s.Severes.GetAsync()).FirstOrDefault(x => x.Date == date)),
                    TestNumber = CovidDbObjectToInt((await covid19s.Tests.GetAsync()).FirstOrDefault(x => x.Date == date)),
                });


                count++;
            }

            //一部累計データがあるので分解
            var deathNumbers = (int[])DataConverter.SumToUnit(items.Select(x => x.DeathNumber).ToArray());
            var recoveryNumbers = (int[])DataConverter.SumToUnit(items.Select(x => x.RecoveryNumber).ToArray());
            
            count = 0;
            var result = new List<Infection>();
            foreach (var item in items)
            {
                var tmp = item;
                tmp.DeathNumber = deathNumbers[count];
                tmp.RecoveryNumber = recoveryNumbers[count];
                result.Add(tmp);
                count++;
            }

            
            return result;
        }

        public async Task<IEnumerable<Infection>> CreateTotalAsync(IList<Infection> infections, IList<string> dates)
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

        private static async Task<IList<string>> GetDatesAsync(ICovid19Repository covid19s)
        {
            //キーデータ取得
            var lineItems = (await covid19s.CovidLineItems.GetAsync()).OrderBy(x => DateTime.Parse(x.Date));
            var dates = new List<string>();
            foreach (var item in lineItems)
            {
                dates.Add(item.Date);
            }
            return dates;
        }

        private static int CovidDbObjectToInt(CovidDbObject obj)
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

    }
}
