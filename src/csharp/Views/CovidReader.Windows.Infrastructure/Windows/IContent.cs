using CovidReader.Windows.Infrastructure.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure.Windows
{
    /// <summary>
    /// Defines the optional contract for content loaded in a ModernFrame.
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// Called when navigation to a content fragment begins.
        /// </summary>
        /// <param name="e">An object that contains the navigation data.</param>
        void OnFragmentNavigation(FragmentNavigationEventArgs e);
        
    }
}
