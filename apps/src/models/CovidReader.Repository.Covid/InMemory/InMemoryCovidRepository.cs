using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.InMemory
{
    public class InMemoryCovidRepository : ICovidRepository
    {
        public InMemoryCovidRepository()
        {

        }

        public IDeathRepository Deathes => new InMemoryDeathRepository();

        public IHospitalizationRepository Hospitalizations => new InMemoryHospitalizationRepository();

        public IPositiveRepository Positives => new InMemoryPositiveRepository();

        public IRecoveryRepository Recoveries => new InMemoryRecoveryRepository();

        public ISevereRepository Severes => new InMemorySevereRepository();

        public ITestRepository Tests => new InMemoryTestRepository();

        public ITestDetailRepository TestDetails => new InMemoryTestDetailRepository();

        public ICovidLineItemRepository CovidLineItems => new InMemoryCovidLineItemRepository();

    }
}
