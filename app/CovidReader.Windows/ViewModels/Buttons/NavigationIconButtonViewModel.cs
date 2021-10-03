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
        
        public string Title { get; set; }
        
        public string IconKey { get; set; }
        
        
        public bool IsSelected { get; set; }
        
    }
}
