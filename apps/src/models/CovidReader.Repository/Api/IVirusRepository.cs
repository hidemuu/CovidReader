using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IVirusRepository
    {
        Task<IEnumerable<Virus>> GetAsync();
        Task<Virus> GetAsync(string date);
        Task PostAsync(Virus item);
        Task PostAsync(IEnumerable<Virus> items);
        Task DeleteAsync(string date);
    }
}
