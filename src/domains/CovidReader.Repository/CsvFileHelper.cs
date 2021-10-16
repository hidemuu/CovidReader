using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace CovidReader.Repository
{
    /// <summary>
    /// CSV入出力ロジック
    /// </summary>
    public class CsvFileHelper
    {
        private string _fileName;
        private string _encode;
        EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encode">エンコード</param>
        public CsvFileHelper(string fileName, string encode)
        {
            _fileName = fileName;
            _encode = encode;
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Write<T>(IEnumerable<T> list)
        {
            var isExist = File.Exists(_fileName);

            var configuration = new CsvConfiguration(CultureInfo.CurrentCulture);
            configuration.HasHeaderRecord = true;
            
            using (var sw = new StreamWriter(_fileName, true, provider.GetEncoding(_encode)))
            {
                using (var csv = new CsvWriter(sw, configuration))
                {
                    //csv.Context.RegisterClassMap<M>();
                    // 区切り文字をタブとかに変えることも可能
                    //config.Delimiter = "\t";
                    csv.WriteRecords(list);
                }
            }
            
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Read<T>()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var sr = new StreamReader(_fileName, provider.GetEncoding(_encode)))
            {
                using (var csv = new CsvReader(sr, configuration))
                {
                    var records = new List<T>();

                    //csv.Context.RegisterClassMap<M>();
                    //records = csv.GetRecords<T>();

                    //読み込み開始準備を行います
                    csv.Read();
                    //ヘッダを読み込みます
                    csv.ReadHeader();
                    //行毎に読み込みと処理を行います
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<T>();
                        records.Add(record);
                    }

                    return records;
                }
            }
            
        }
    }
}
