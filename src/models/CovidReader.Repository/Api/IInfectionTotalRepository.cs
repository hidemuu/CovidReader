using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IInfectionTotalRepository
    {
        Task<IEnumerable<InfectionTotal>> GetAsync();
        Task<InfectionTotal> GetAsync(string date);
        Task PostAsync(InfectionTotal item);
        Task PostAsync(IEnumerable<InfectionTotal> items);
        Task DeleteAsync(string date);
    }
}
