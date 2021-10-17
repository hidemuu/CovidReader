using CovidReader.Windows.Views;
using CovidReader.Windows.ViewUtility.Constants;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class DashboardViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionNavigationJournal journal;
        public IRegionManager RegionManager { get; }

        public bool KeepAlive => true;

        public DashboardViewModel(IRegionManager regionManager)
        {
            this.RegionManager = regionManager;
            this.RegionManager.RequestNavigate(RegionNames.DashboardLeftRegion, nameof(InfectionChartView));
            this.RegionManager.RequestNavigate(RegionNames.DashboardRightRegion, nameof(InfectionTableView));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// この画面から他の画面に遷移する時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 他の画面からこの画面に遷移してきた時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;
            

        }

    }
}
