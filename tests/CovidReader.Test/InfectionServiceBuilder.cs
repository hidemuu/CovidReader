using CovidReader.Service.Api;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Test
{
    public class InfectionServiceBuilder
    {
        private readonly InfectionService _infectionService;
        private readonly Mock<IInfectionRepository> _mockRepository;
        public Mock<IEnumerable<Infection>> MockInfections { get; private set; }

        public InfectionServiceBuilder()
        {
            _mockRepository = new Mock<IInfectionRepository>();
            _infectionService = new InfectionService(_mockRepository.Object);
        }

        public InfectionServiceBuilder WithInfectionCalled()
        {
            MockInfections = new Mock<IEnumerable<Infection>>();
            _mockRepository.Setup(r => r.GetAsync()).ReturnsAsync(MockInfections.Object);
            return this;
        }

        public InfectionService Build()
        {
            return _infectionService;
        }

    }
}
