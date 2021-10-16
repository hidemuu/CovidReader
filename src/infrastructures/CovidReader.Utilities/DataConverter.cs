using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Utilities
{
    /// <summary>
    /// データ変換ロジック
    /// </summary>
    public class DataConverter
    { /// <summary>
    /// 文字列データを数値データに変換　変換不可なら0か指定した数値を返す
    /// </summary>
    /// <param name="value">変換対象文字列データ</param>
    /// <param name="def">変換不可時の返値</param>
    /// <returns></returns>
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
        /// <summary>
        /// 単日データリストを累積データリストに変換
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 累積データリストを単日データリストに変換
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// <summary>
        /// データリストが単日データならtrueを返す
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
