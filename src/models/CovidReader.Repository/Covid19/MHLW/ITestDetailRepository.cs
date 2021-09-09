using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    public interface ITestDetailRepository
    {
        Task<IEnumerable<TestDetail>> GetAsync();
        Task<TestDetail> GetAsync(string date);
        Task PostAsync(TestDetail test);
        Task PostAsync(IEnumerable<TestDetail> items);
        Task DeleteAsync(string date);
    }
}
