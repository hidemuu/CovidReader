using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    public interface ISevereRepository
    {
        Task<IEnumerable<Severe>> GetAsync();
        Task<Severe> GetAsync(string date);
        Task PostAsync(Severe severe);
        Task PostAsync(IEnumerable<Severe> items);
        Task DeleteAsync(string date);
    }
}
