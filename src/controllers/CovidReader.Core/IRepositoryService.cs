using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core
{
    public interface IRepositoryService<T>
    {
        Task ImportAsync(T data);

        Task ExportAsync(T data);
    }
}
