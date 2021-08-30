using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface IDeathRepository
    {
        Task<IEnumerable<Death>> GetAsync();
        Task<Death> GetAsync(string date);
        Task PostAsync(Death death);
        Task PostAsync(IEnumerable<Death> items);
        Task DeleteAsync(string date);
    }
}
