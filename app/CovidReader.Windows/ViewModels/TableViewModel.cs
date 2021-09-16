﻿using CovidReader.Models.Api;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class TableViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionNavigationJournal _journal;
        //private readonly IRegionManager _regionManager;

        public bool KeepAlive => true;

        public ObservableCollection<Infection> Models { get; }

        public TableViewModel()
        {
            Models = new ObservableCollection<Infection>();
            var task = App.NativeController.ApiRepository.Infections.GetAsync();
            Task.WaitAll(task);
            foreach (var item in task.Result)
            {
                Models.Add(item);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //MessageBox.Show("退出了LoginMainContent");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //MessageBox.Show("从CreateAccount导航到LoginMainContent");
            _journal = navigationContext.NavigationService.Journal;


        }
    }
}
