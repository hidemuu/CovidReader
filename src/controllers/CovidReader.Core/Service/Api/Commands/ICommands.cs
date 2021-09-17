using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core
{
    public interface ICommands<T>
    {
        Task SaveAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
