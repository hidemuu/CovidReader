using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Service
{
    public interface ICovid19Service
    {
        Task MapperToRepositoryAsync();
        Task PostAsync(IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests, IEnumerable<TestDetail> testDetails);
        Task<IEnumerable<T>> GetAsync<T>() where T : CovidDbObject;
    }
}
