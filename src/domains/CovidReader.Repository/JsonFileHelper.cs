using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CovidReader.Repository
{
    /// <summary>
    /// JSONファイル入出力ロジック
    /// </summary>
    public class JsonFileHelper
    {
        private string _fileName;
        private string _encode;
        EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encode">エンコード</param>
        public JsonFileHelper(string fileName, string encode)
        {
            _fileName = fileName;
            _encode = encode;
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Read<T>()
        {
            //Json文字列の取得
            string jsonString = ReadStream();
            //指定オブジェクトにデシリアライズ
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Write<T>(T obj)
        {
            //Jsonデータにシリアライズ
            var json = JsonConvert.SerializeObject(obj);
            WriteStream(json, false);
        }

        private string ReadStream()
        {
            using (var stream = new StreamReader(_fileName, provider.GetEncoding(_encode)))
            {
                if (stream != null)
                {
                    return stream.ReadToEnd();
                }
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="isappend">追記モード（falseなら上書き保存）</param>
        private void WriteStream(string json, bool isappend)
        {
            using (var stream = new StreamWriter(_fileName, isappend, provider.GetEncoding(_encode)))
            {
                if (stream != null)
                {
                    stream.Write(json);
                }
            }
        }
    }
}
