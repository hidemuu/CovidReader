using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core
{
    public class Curd<T> : IRead<T>, ISave<T>, IDelete<T>
    {
        
        public T Read(Guid id)
        {
            return default(T);
        }

        public IEnumerable<T> ReadAll()
        {
            return new List<T>();
        }

        public void Save(T entity)
        {
            
        }

        public void Delete(T entity)
        {
            
        }

    }
}
