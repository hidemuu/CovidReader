using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// 検査データリポジトリ
    /// </summary>
    public interface IInspectionRepository : IApiItemRepository<Inspection>
    {
        
    }
}
