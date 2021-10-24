using CovidReader.UseCases;
using CovidReader.Models.Api;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Repository.Api;
using CovidReader.Windows.Models;

namespace CovidReader.Windows.ViewModels
{
    public class InfectionTableViewModel : InfectionViewModelBase
    {

        #region プロパティ

        /// <summary>
        /// ビューバインディングモデル
        /// </summary>
        public ReadOnlyReactiveCollection<InfectionModel> Models { get; }

        #endregion

       
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="apiRepository"></param>
        public InfectionTableViewModel(IRegionManager regionManager, IApiRepository apiRepository) : base(regionManager, apiRepository)
        {
            this.Models = Infections.ToReadOnlyReactiveCollection(c => new InfectionModel(c));

        }

    }

}
