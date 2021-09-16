using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    public interface IInspectionRepository
    {
        Task<IEnumerable<Inspection>> GetAsync();
        Task<Inspection> GetAsync(string date);
        Task PostAsync(Inspection item);
        Task PostAsync(IEnumerable<Inspection> items);
        Task DeleteAsync(string date);
    }
}
