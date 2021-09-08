using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface IPositiveRepository
    {
        Task<IEnumerable<Positive>> GetAsync();
        Task<Positive> GetAsync(string date);
        Task PostAsync(Positive positive);
        Task PostAsync(IEnumerable<Positive> items);
        Task DeleteAsync(string date);
    }
}
