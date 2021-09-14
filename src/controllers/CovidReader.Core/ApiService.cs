using CovidReader.Core.Plugins.Accesses;
using CovidReader.Core.Plugins.Utilities;
using CovidReader.Models;
using CovidReader.Models.Api;
using CovidReader.Models.Covid19;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core
{
    

    public class ApiService
    {
        private ApiRepositoryHelper _api;
        private CovidRepositoryHelper _covid;

        public ApiService(IApiRepository repository, ICovidRepository covids)
        {
            _api = new ApiRepositoryHelper(repository);
            _covid = new CovidRepositoryHelper(covids);
        }

        
        /// <summary>
        /// 外部データをリポジトリにインポート
        /// </summary>
        /// <param name="repository">インポート元外部データ</param>
        /// <returns></returns>
        public async Task ImportAsync(ICovidRepository repository)
        {
            Console.WriteLine("Importing...");
            await _covid.ImportAsync(repository);
        }

        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(ICovidRepository repository)
        {
            Console.WriteLine("Exporting...");
            await _covid.ExportAsync(repository);
        }

        /// <summary>
        /// リポジトリデータを外部にエクスポート
        /// </summary>
        /// <param name="repository">エクスポート先外部データ</param>
        /// <returns></returns>
        public async Task ExportAsync(IApiRepository repository)
        {
            Console.WriteLine("Exporting...");
            await _api.ExportAsync(repository);
        }

        
        /// <summary>
        /// CovidデータベースデータをApiデータベーステーブルに格納
        /// </summary>
        /// <returns></returns>
        public async Task CovidToApiAsync()
        {
            //キーデータ取得
            var lineItems = (await _covid.GetRepository().CovidLineItems.GetAsync()).OrderBy(x => DateTime.Parse(x.Date));
            var dates = new List<string>();
            foreach (var item in lineItems)
            {
                dates.Add(item.Date);
            }

            var count = 0;

            //感染データ取得
            var deathNumbers = new int[dates.Count];
            var cureNumbers = new int[dates.Count];
            var patientNumbers = new int[dates.Count];
            var recoveryNumbers = new int[dates.Count];
            var severeNumbers = new int[dates.Count];
            var testNumbers = new int[dates.Count];
            count = 0;
            foreach (var date in dates)
            {
                deathNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Deathes.GetAsync()).FirstOrDefault(x => x.Date == date));
                cureNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Hospitalizations.GetAsync()).FirstOrDefault(x => x.Date == date));
                patientNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Positives.GetAsync()).FirstOrDefault(x => x.Date == date));
                recoveryNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Recoveries.GetAsync()).FirstOrDefault(x => x.Date == date));
                severeNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Severes.GetAsync()).FirstOrDefault(x => x.Date == date));
                testNumbers[count] = CovidDbObjectToInt((await _covid.GetRepository().Tests.GetAsync()).FirstOrDefault(x => x.Date == date));
                count++;
            }
            deathNumbers = (int[])DataConverter.SumToUnit(deathNumbers);
            recoveryNumbers = (int[])DataConverter.SumToUnit(recoveryNumbers);

            //感染累計データ取得
            var deathSums = (int[])DataConverter.UnitToSum(deathNumbers);
            var cureSums = (int[])DataConverter.UnitToSum(cureNumbers);
            var patientSums = (int[])DataConverter.UnitToSum(patientNumbers);
            var recoverySums = (int[])DataConverter.UnitToSum(recoveryNumbers);
            var severeSums = (int[])DataConverter.UnitToSum(severeNumbers);
            var testSums = (int[])DataConverter.UnitToSum(testNumbers);

            //検査詳細データ取得
            var nationalTestNumbers = new int[dates.Count];
            var quarantineTestNumbers = new int[dates.Count];
            var careCenterTestNumbers = new int[dates.Count];
            var civilCenterTestNumbers = new int[dates.Count];
            var collegeTestNumbers = new int[dates.Count];
            var medicalTestNumbers = new int[dates.Count];
            count = 0;
            foreach (var date in dates)
            {
                var testDetail = (await _covid.GetRepository().TestDetails.GetAsync()).FirstOrDefault(x => x.Date == date);

                if (testDetail != null)
                {
                    nationalTestNumbers[count] = DataConverter.StringToInt(testDetail.Number);
                    quarantineTestNumbers[count] = DataConverter.StringToInt(testDetail.QuarantineNumber);
                    careCenterTestNumbers[count] = DataConverter.StringToInt(testDetail.CareCenterNumber);
                    civilCenterTestNumbers[count] = DataConverter.StringToInt(testDetail.CivilCenterNumber);
                    collegeTestNumbers[count] = DataConverter.StringToInt(testDetail.CollegeNumber);
                    medicalTestNumbers[count] = DataConverter.StringToInt(testDetail.MedicalNumber);
                }
                count++;
            }

            //検査詳細累計データ取得
            var nationalTestSums = (int[])DataConverter.UnitToSum(nationalTestNumbers);
            var quarantineTestSums = (int[])DataConverter.UnitToSum(quarantineTestNumbers);
            var careCenterTestSums = (int[])DataConverter.UnitToSum(careCenterTestNumbers);
            var civilCenterTestSums = (int[])DataConverter.UnitToSum(civilCenterTestNumbers);
            var collegeTestSums = (int[])DataConverter.UnitToSum(collegeTestNumbers);
            var medicalTestSums = (int[])DataConverter.UnitToSum(medicalTestNumbers);

            //感染データ登録
            Console.WriteLine("Covid->Api...");
            

            //List<Virus> viruses = new List<Virus>();
            //foreach (var date in dates)
            //{
            //    viruses.Add(new Virus
            //    {
            //        Id = count,
            //        Date = date,
            //        Name = "",
            //        DeathNumber = deathNumber,
            //        HospitalizationNumber = cureNumber,
            //        PositiveNumber = patientNumber,
            //        RecoveryNumber = recoveryNumber,
            //        SevereNumber = severeNumber,
            //        TestNumber = testNumber,
            //        NationalTestNumber = nationalTestNumber,
            //        QuarantineTestNumber = quarantineTestNumber,
            //        CareCenterTestNumber = careCenterTestNumber,
            //        CivilCenterTestNumber = civilCenterTestNumber,
            //        CollegeTestNumber = collegeTestNumber,
            //        MedicalTestNumber = medicalTestNumber,
            //    });
            //    count++;
            //}
            //await _api.GetRepository().Viruses.PostAsync(viruses);

            var infections = new List<Infection>();
            var vitalTests = new List<ViralTest>();
            var infectionSums = new List<InfectionTotal>();
            var vitalTestSums = new List<ViralTestTotal>();
            count = 0;
            foreach (var date in dates)
            {
                infections.Add(new Infection {
                    Id = count,
                    Date = date,
                    CountryName = "Japan",
                    DeathNumber = deathNumbers[count],
                    CureNumber = cureNumbers[count],
                    PatientNumber = patientNumbers[count],
                    RecoveryNumber = recoveryNumbers[count],
                    SevereNumber = severeNumbers[count],
                    TestNumber = testNumbers[count],
                });

                vitalTests.Add(new ViralTest {
                    Id = count,
                    Date = date,
                    CountryName = "Japan",
                    NationalTestNumber = nationalTestNumbers[count],
                    QuarantineTestNumber = quarantineTestNumbers[count],
                    CareCenterTestNumber = careCenterTestNumbers[count],
                    CivilCenterTestNumber = civilCenterTestNumbers[count],
                    CollegeTestNumber = collegeTestNumbers[count],
                    MedicalTestNumber = medicalTestNumbers[count],
                });

                infectionSums.Add(new InfectionTotal
                {
                    Id = count,
                    Date = date,
                    CountryName = "Japan",
                    DeathNumber = deathSums[count],
                    CureNumber = cureSums[count],
                    PatientNumber = patientSums[count],
                    RecoveryNumber = recoverySums[count],
                    SevereNumber = severeSums[count],
                    TestNumber = testSums[count],
                });

                vitalTestSums.Add(new ViralTestTotal
                {
                    Id = count,
                    Date = date,
                    CountryName = "Japan",
                    NationalTestNumber = nationalTestSums[count],
                    QuarantineTestNumber = quarantineTestSums[count],
                    CareCenterTestNumber = careCenterTestSums[count],
                    CivilCenterTestNumber = civilCenterTestSums[count],
                    CollegeTestNumber = collegeTestSums[count],
                    MedicalTestNumber = medicalTestSums[count],
                });

                count++;
            }
            await _api.GetRepository().Infections.PostAsync(infections);
            await _api.GetRepository().ViralTests.PostAsync(vitalTests);
            await _api.GetRepository().InfectionTotals.PostAsync(infectionSums);
            await _api.GetRepository().ViralTestTotals.PostAsync(vitalTestSums);

        }

        /// <summary>
        /// VirusテーブルデータをChartItemテーブルに変換して格納 / ChartConfigテーブルデータを更新
        /// </summary>
        /// <returns></returns>
        public async Task ToChartItemAsync()
        {
            await _api.ToChartItemAsync();
        }

        private static int CovidDbObjectToInt(CovidDbObject obj)
        {
            if(obj != null)
            {
                return DataConverter.StringToInt(obj.Number, 0);
            }
            else
            {
                return 0;
            }
        }


        //private async Task InitializeAsync()
        //{
        //    var apiDb = (await _settingRepository.Configs.GetAsync("ApiDB")).Val;
        //    var covidDb = (await _settingRepository.Configs.GetAsync("CovidDB")).Val;
        //}

    }
}
