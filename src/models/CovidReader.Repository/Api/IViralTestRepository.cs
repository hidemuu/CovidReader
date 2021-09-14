using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IViralTestRepository
    {
        Task<IEnumerable<ViralTest>> GetAsync();
        Task<ViralTest> GetAsync(string date);
        Task PostAsync(ViralTest item);
        Task PostAsync(IEnumerable<ViralTest> items);
        Task DeleteAsync(string date);
    }
}
