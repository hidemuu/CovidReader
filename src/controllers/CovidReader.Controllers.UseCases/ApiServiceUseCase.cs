using CovidReader.Core.Service;
using CovidReader.Repository.Api;
using CovidReader.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Controllers.UseCases
{
    public class ApiServiceUseCase
    {
        public static IApiService Create(string repositoryType, string mapperType)
        {
            IApiRepository repository = GetRepository(repositoryType);
            IApiRepository mapper = GetRepository(mapperType);

            return new ApiService(repository, mapper);
        }

        private static IApiRepository GetRepository(string name)
        {
            IApiRepository repository;
            switch (name)
            {
                case "sql": repository = ApiRepositoryUseCase.UseSqlite(); break;
                case "json": repository = ApiRepositoryUseCase.UseJson(); break;
                case "csv": repository = ApiRepositoryUseCase.UseCsv(); break;
                case "rest": repository = ApiRepositoryUseCase.UseREST(); break;
                default: repository = ApiRepositoryUseCase.UseSqlite(); break;
            }
            return repository;
        }

    }
}
