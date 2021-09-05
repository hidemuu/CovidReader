using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
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
