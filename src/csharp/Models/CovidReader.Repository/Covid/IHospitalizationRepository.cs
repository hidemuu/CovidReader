using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface IHospitalizationRepository
    {
        Task<IEnumerable<Hospitalization>> GetAsync();
        Task<Hospitalization> GetAsync(string date);
        Task PostAsync(Hospitalization hospitalization);
        Task PostAsync(IEnumerable<Hospitalization> items);
        Task DeleteAsync(string date);
    }
}
