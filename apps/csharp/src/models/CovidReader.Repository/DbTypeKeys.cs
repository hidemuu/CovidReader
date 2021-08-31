using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository
{
    public enum DbTypeKeys
    {
        None = -1,
        Csv = 0, 
        Json = 1,
        Sql = 2, 
        Rest = 3
    }
}
