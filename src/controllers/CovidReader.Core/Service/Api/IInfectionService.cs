using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Service
{
    public interface IInfectionService
    {
        Task PostAsync(IEnumerable<Infection> items);
        Task<IEnumerable<Infection>> GetAsync();
        Task CreateAsync(IList<string> dates, IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests);

        Task<IEnumerable<Infection>> CreateDailyAsync(IList<string> dates, IEnumerable<Death> deaths, IEnumerable<Hospitalization> hospitalizations, IEnumerable<Positive> positives, IEnumerable<Recovery> recoveries, IEnumerable<Severe> severes, IEnumerable<Test> tests);

        Task<IEnumerable<Infection>> CreateTotalAsync(IList<Infection> infections, IList<string> dates);
    }
}
