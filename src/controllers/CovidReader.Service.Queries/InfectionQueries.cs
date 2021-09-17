using CovidReader.Core;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Service.Queries
{
    public class InfectionQueries : IQueries<Infection>
    {
        private readonly IInfectionRepository _repository;

        public InfectionQueries(IInfectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Infection>> ReadAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Infection> ReadAsync(Guid id)
        {
            return (await _repository.GetAsync()).FirstOrDefault(x => x.Id == id);
        }

    }
}
