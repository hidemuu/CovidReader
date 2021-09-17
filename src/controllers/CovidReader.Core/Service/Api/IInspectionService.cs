using CovidReader.Models.Api;
using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Service
{
    public interface IInspectionService
    {
        Task PostAsync(IEnumerable<Inspection> items);
        Task<IEnumerable<Inspection>> GetAsync();
        Task CreateAsync(IList<string> dates, IEnumerable<TestDetail> testDetails);

        Task<IEnumerable<Inspection>> CreateDailyAsync(IList<string> dates, IEnumerable<TestDetail> testDetails);

        Task<IEnumerable<Inspection>> CreateTotalAsync(IList<Inspection> inspections, IList<string> dates);
    }
}
