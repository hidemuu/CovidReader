using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
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
