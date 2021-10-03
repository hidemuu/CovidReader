using CovidReader.Windows.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public interface IContentViewModel
    {
        NavigationIconButtonViewModel NavigationIconButtonViewModel { get; }
    }
}
