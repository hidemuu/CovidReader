using CovidReader.Models.Api;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Models
{
    public class InfectionModel
    {
        public ReactivePropertySlim<string> Date { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<int> PatientNumber { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> DeathNumber { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> CureNumber { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> RecoveryNumber { get; } = new ReactivePropertySlim<int>();

        public InfectionModel(Infection model)
        {
            Date.Value = model.Date;
            PatientNumber.Value = model.PatientNumber;
            DeathNumber.Value = model.DeathNumber;
            CureNumber.Value = model.CureNumber;
            RecoveryNumber.Value = model.RecoveryNumber;
        }
    }
}
