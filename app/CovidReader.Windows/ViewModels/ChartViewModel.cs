using CovidReader.Windows.ViewModels.Buttons;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class ChartViewModel : BindableBase, INavigationAware, IRegionMemberLifetime, IContentViewModel
    {
        public NavigationIconButtonViewModel NavigationIconButtonViewModel =>
            new NavigationIconButtonViewModel { Title = "Chart", IconKey = "Home" };

        private IRegionNavigationJournal _journal;
        //private readonly IRegionManager _regionManager;

        public bool KeepAlive => true;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;


        }
    }
}
