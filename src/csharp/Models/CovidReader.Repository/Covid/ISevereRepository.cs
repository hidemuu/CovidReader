using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
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
