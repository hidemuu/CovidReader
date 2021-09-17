using CovidReader.Core;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Commands
{
    public class InfectionCommands : ICommands<Infection>
    {
        private readonly IInfectionRepository _repository;

        public InfectionCommands(IInfectionRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveAsync(Infection infection)
        {
            await _repository.PostAsync(infection);
        }

        public async Task DeleteAsync(Infection infection)
        {
            await _repository.DeleteAsync(infection.Date);
        }

    }
}
