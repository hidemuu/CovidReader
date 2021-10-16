using CovidReader.Windows.ViewUtility.Constants;
using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CovidReader.ViewControls.Wpf.Services
{
    public class FlyoutService : IFlyoutService
    {
        IRegionManager _regionManager;
        IApplicationCommands _applicationCommands;

        public ICommand ShowFlyoutCommand { get; private set; }
        public FlyoutService(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            _regionManager = regionManager;
            _applicationCommands = applicationCommands;

            this.ShowFlyoutCommand = new DelegateCommand<string>(ShowFlyout);
            
            _applicationCommands.ShowCommand.RegisterCommand(this.ShowFlyoutCommand);

        }
        public void ShowFlyout(string flyoutName)
        {
            var region = _regionManager.Regions[RegionNames.FlyoutRegion];

            if (region != null)
            {
                var flyout = region.Views.Where(v => v is IFlyoutView && ((IFlyoutView)v).FlyoutName.Equals(flyoutName)).FirstOrDefault() as Flyout;

                if (flyout != null)
                {
                    flyout.IsOpen = !flyout.IsOpen;
                }
            }
        }
    }
}
