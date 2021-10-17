using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.InMemory
{
    public class InMemoryCovid19Repository : ICovid19Repository, ICovid19Mapper
    {
        public InMemoryCovid19Repository()
        {
            Deathes = new InMemoryDeathRepository();
            Hospitalizations = new InMemoryHospitalizationRepository();
            Positives = new InMemoryPositiveRepository();
            Recoveries = new InMemoryRecoveryRepository();
            Severes = new InMemorySevereRepository();
            Tests = new InMemoryTestRepository();
            TestDetails = new InMemoryTestDetailRepository();
            CovidLineItems = new InMemoryCovid19LineItemRepository();
        }

        public IDeathRepository Deathes { get; }

        public IHospitalizationRepository Hospitalizations { get; }

        public IPositiveRepository Positives { get; }

        public IRecoveryRepository Recoveries { get; }

        public ISevereRepository Severes { get; }

        public ITestRepository Tests { get; }

        public ITestDetailRepository TestDetails { get; }

        public ICovid19LineItemRepository CovidLineItems { get; }

    }
}
