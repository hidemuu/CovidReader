using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CovidReader.Windows.ViewModels;
using MahApps.Metro.Controls;
using Prism.Ioc;
using Prism.Regions;

namespace CovidReader.Windows.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();

            //var regionManager = ContainerLocator.Current.Resolve<IRegionManager>();
            //if (regionManager != null)
            //{
            //    SetRegionManager(regionManager, this.flyoutsControlRegion, "FlyoutRegion");
            //    SetRegionManager(regionManager, this.rightWindowCommandsRegion, "ShowSearchPatientRegion");
            //}


        }

        //private void SetRegionManager(IRegionManager regionManager, DependencyObject regionTarget, string regionName)
        //{
        //    RegionManager.SetRegionName(regionTarget, regionName);
        //    RegionManager.SetRegionManager(regionTarget, regionManager);
        //}

    }
}
