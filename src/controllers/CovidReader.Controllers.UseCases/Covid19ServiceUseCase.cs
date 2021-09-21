using CovidReader.Service;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Service.Covid19;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Controllers.UseCases
{
    /// <summary>
    /// Covid19 APIアクセスサービス生成のユースケース
    /// </summary>
    public class Covid19ServiceUseCase
    {
        /// <summary>
        /// サービス生成
        /// mapperで外部からデータをインポートし、必要に応じてrepositoryに更新する。
        /// アプリケーションのコントロールはrepositoryで行う
        /// </summary>
        /// <param name="repositoryType">データベースリポジトリのファイル形式名称(sql / json / csv / inmemory)</param>
        /// <param name="mapperType">インポート用ファイルのファイル形式名称(sql / json / csv / inmemory)</param>
        /// <returns></returns>
        public static ICovid19Service Create(string repositoryType, string mapperType)
        {
            ICovid19Repository repository = GetRepository(repositoryType);
            ICovid19Repository mapper = GetRepository(mapperType);
            return new Covid19Service(repository, mapper);
        }

        private static ICovid19Repository GetRepository(string name)
        {
            ICovid19Repository repository;
            switch (name)
            {
                case "sql": repository = Covid19RepositoryUseCase.UseSqlite(); break;
                case "json": repository = Covid19RepositoryUseCase.UseJson(); break;
                case "csv": repository = Covid19RepositoryUseCase.UseCsv(); break;
                case "inmemory": repository = Covid19RepositoryUseCase.UseInMemory(); break;
                default: repository = Covid19RepositoryUseCase.UseSqlite(); break;
            }
            return repository;
        }

    }
}
