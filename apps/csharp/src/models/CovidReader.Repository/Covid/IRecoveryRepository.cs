using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface IRecoveryRepository
    {
        Task<IEnumerable<Recovery>> GetAsync();
        Task<Recovery> GetAsync(string date);
        Task PostAsync(Recovery recovery);
        Task PostAsync(IEnumerable<Recovery> items);
        Task DeleteAsync(string date);
    }
}
