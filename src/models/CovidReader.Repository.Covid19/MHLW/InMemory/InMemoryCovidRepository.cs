using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.InMemory
{
    public class InMemoryCovidRepository : ICovidRepository
    {
        public InMemoryCovidRepository()
        {
            Deathes = new InMemoryDeathRepository();
            Hospitalizations = new InMemoryHospitalizationRepository();
            Positives = new InMemoryPositiveRepository();
            Recoveries = new InMemoryRecoveryRepository();
            Severes = new InMemorySevereRepository();
            Tests = new InMemoryTestRepository();
            TestDetails = new InMemoryTestDetailRepository();
            CovidLineItems = new InMemoryCovidLineItemRepository();
        }

        public IDeathRepository Deathes { get; }

        public IHospitalizationRepository Hospitalizations { get; }

        public IPositiveRepository Positives { get; }

        public IRecoveryRepository Recoveries { get; }

        public ISevereRepository Severes { get; }

        public ITestRepository Tests { get; }

        public ITestDetailRepository TestDetails { get; }

        public ICovidLineItemRepository CovidLineItems { get; }

    }
}
