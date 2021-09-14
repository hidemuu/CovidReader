using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IViralTestTotalRepository
    {
        Task<IEnumerable<ViralTestTotal>> GetAsync();
        Task<ViralTestTotal> GetAsync(string date);
        Task PostAsync(ViralTestTotal item);
        Task PostAsync(IEnumerable<ViralTestTotal> items);
        Task DeleteAsync(string date);
    }
}
