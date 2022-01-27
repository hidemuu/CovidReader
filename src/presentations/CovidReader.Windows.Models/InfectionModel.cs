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
            this.Date.Value = model.Date;
            this.PatientNumber.Value = model.PatientNumber;
            this.DeathNumber.Value = model.DeathNumber;
            this.CureNumber.Value = model.CureNumber;
            this.RecoveryNumber.Value = model.RecoveryNumber;
        }
    }
}
