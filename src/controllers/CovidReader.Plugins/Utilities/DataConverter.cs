using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Plugins.Utilities
{
    public class DataConverter
    {
        public static int StringToInt(string value, int def = 0)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                return def;
            }
        }
    }
}
