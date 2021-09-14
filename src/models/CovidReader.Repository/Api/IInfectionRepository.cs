using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IInfectionRepository
    {
        Task<IEnumerable<Infection>> GetAsync();
        Task<Infection> GetAsync(string date);
        Task PostAsync(Infection item);
        Task PostAsync(IEnumerable<Infection> items);
        Task DeleteAsync(string date);
    }
}
