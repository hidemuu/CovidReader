using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Core.Utilities
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

        public static IEnumerable<int> UnitToSum(int[] data)
        {
            var result = new int[data.Length];
            result[0] = data[0];
            for (var i = 1; i < data.Length; i++)
            {
                result[i] = data[i] + result[i - 1];
            }
            return result;
        }

        public static IEnumerable<int> SumToUnit(int[] data)
        {
            var result = new int[data.Length];
            result[0] = data[0];
            for (var i = data.Length - 1; i > 0; i--)
            {
                var unit = data[i] - data[i - 1];
                if(unit > 0)
                {
                    result[i] = unit;
                }
                else
                {
                    result[i] = 0;
                }
                
            }
            return result;
        }

        public static bool IsUnit(int[] data)
        {
            for (var i = 0; i < data.Length - 1; i++)
            {
                if (data[i] > data[i + 1]) return true;
            }
            return false;
        }

    }
}
