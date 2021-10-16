using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    /// <summary>
    /// 重傷者数
    /// </summary>
    public interface ISevereRepository : ICovid19ItemRepository<Severe>
    {
        
    }
}
