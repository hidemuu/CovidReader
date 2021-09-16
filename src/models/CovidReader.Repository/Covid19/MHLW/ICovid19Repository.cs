using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW
{
    public interface ICovid19Repository
    {
        IDeathRepository Deathes { get; }

        IHospitalizationRepository Hospitalizations { get; }

        IPositiveRepository Positives { get; }

        IRecoveryRepository Recoveries { get; }

        ISevereRepository Severes { get; }

        ITestRepository Tests { get; }

        ITestDetailRepository TestDetails { get; }

        ICovid19LineItemRepository CovidLineItems { get; }

    }
}
