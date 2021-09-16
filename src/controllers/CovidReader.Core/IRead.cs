using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core
{
    public interface IRead<T>
    {
        T Read(Guid id);

        IEnumerable<T> ReadAll();
    }
}
