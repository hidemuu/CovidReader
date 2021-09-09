using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    public interface ICovidLineItemRepository
    {
        Task<IEnumerable<CovidLineItem>> GetAsync();
        Task<CovidLineItem> GetAsync(string date);
        Task PostAsync(CovidLineItem item);
        Task PostAsync(IEnumerable<CovidLineItem> items);
    }
}
