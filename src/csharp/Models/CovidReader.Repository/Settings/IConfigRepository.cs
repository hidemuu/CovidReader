using CovidReader.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Settings
{
    public interface IConfigRepository
    {
        Task<IEnumerable<Config>> GetAsync();
        Task<Config> GetAsync(string name);
    }
}
