using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels.Buttons
{
    public class NavigationIconButtonViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        private string _iconKey;

        public string IconKey
        {
            get => _iconKey;
            set => SetProperty(ref _iconKey, value);
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

    }
}
