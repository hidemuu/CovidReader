using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core
{
    public interface IQueries<T>
    {
        Task<T> ReadAsync(Guid id);

        Task<IEnumerable<T>> ReadAllAsync();
    }
}
