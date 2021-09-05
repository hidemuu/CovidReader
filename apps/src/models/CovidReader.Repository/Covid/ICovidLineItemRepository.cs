using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public interface ICovidLineItemRepository
    {
        Task<IEnumerable<CovidLineItem>> GetAsync();
        Task<CovidLineItem> GetAsync(string date);
        Task PostAsync(CovidLineItem item);
        Task PostAsync(IEnumerable<CovidLineItem> items);
    }
}
