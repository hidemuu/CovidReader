using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// 感染データリポジトリ
    /// </summary>
    public interface IInfectionRepository : IApiItemRepository<Infection>
    {
        
    }
}
