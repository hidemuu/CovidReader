using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    /// <summary>
    /// 検査件数詳細
    /// </summary>
    public interface ITestDetailRepository : ICovid19ItemRepository<TestDetail>
    {
        
    }
}
