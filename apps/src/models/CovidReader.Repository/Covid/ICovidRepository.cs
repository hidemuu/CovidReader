using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid
{
    public interface ICovidRepository
    {
        IDeathRepository Deathes { get; }

        IHospitalizationRepository Hospitalizations { get; }

        IPositiveRepository Positives { get; }

        IRecoveryRepository Recoveries { get; }

        ISevereRepository Severes { get; }

        ITestRepository Tests { get; }

        ITestDetailRepository TestDetails { get; }

        ICovidLineItemRepository CovidLineItems { get; }

    }
}
