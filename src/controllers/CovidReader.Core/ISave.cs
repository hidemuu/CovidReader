using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core
{
    public interface ISave<T>
    {
        void Save(T entity);
    }
}
