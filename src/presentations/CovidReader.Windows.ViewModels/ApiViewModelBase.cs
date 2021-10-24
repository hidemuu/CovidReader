using CovidReader.Repository.Api;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public abstract class ApiViewModelBase : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region フィールド

        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;
        private CompositeDisposable disposables = new CompositeDisposable();
        protected IApiRepository apiRepository;

        #endregion

        #region プロパティ
        public bool KeepAlive => true;

        #endregion

        public ApiViewModelBase(IRegionManager regionManager, IApiRepository apiRepository)
        {
            this.regionManager = regionManager;
            this.apiRepository = apiRepository;
        }

        #region ナビゲーションメソッド

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.journal = navigationContext.NavigationService.Journal;
        }

        #endregion

    }
}
