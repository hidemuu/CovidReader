using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAsync();
        Task<Test> GetAsync(string date);
        Task PostAsync(Test test);
        Task PostAsync(IEnumerable<Test> items);
        Task DeleteAsync(string date);
    }
}
