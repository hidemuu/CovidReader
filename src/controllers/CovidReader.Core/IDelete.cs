using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core
{
    public interface IDelete<T>
    {
        void Delete(T entity);
    }
}
