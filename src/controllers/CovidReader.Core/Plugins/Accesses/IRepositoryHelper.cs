using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Plugins.Accesses
{
    public interface IRepositoryHelper<T>
    {
        T GetRepository();

        Task ImportAsync(T data);

        Task ExportAsync(T data);
    }
}
