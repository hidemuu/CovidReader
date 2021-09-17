using CovidReader.Core.Service;
using CovidReader.Core.Services;
using CovidReader.Repository.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Controllers.UseCases
{
    public class Covid19ServiceUseCase
    {
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
                case "sql": repository = CovidRepositoryUseCase.UseSqlite(); break;
                case "json": repository = CovidRepositoryUseCase.UseJson(); break;
                case "csv": repository = CovidRepositoryUseCase.UseCsv(); break;
                case "inmemory": repository = CovidRepositoryUseCase.UseInMemory(); break;
                default: repository = CovidRepositoryUseCase.UseSqlite(); break;
            }
            return repository;
        }

    }
}
