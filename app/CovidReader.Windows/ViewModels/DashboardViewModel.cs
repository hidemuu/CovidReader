using CovidReader.Windows.ViewModels.Buttons;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class DashboardViewModel : BindableBase, IContentViewModel
    {
        public NavigationIconButtonViewModel NavigationIconButtonViewModel =>
            new NavigationIconButtonViewModel { Title = "DASHBOARD", IconKey = "Cog" };
    }
}
