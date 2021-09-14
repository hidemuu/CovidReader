using CovidReader.Repository.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Core.Plugins.Accesses
{
    public class SettingRepositoryHelper : IRepositoryHelper<ISettingRepository>
    {
        private ISettingRepository _repository;

        public SettingRepositoryHelper(ISettingRepository repository)
        {
            _repository = repository;
        }

        public Task ExportAsync(ISettingRepository data)
        {
            throw new NotImplementedException();
        }

        public ISettingRepository GetRepository()
        {
            return _repository;
        }

        public Task ImportAsync(ISettingRepository data)
        {
            throw new NotImplementedException();
        }
    }
}
