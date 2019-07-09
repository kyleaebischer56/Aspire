using System.Collections.Generic;

namespace Aspire.Navigation.Models
{
    public class NavigationViewModel
    {
        public NavigationViewModel(IEnumerable<NavigationItemViewModel> navigationItems)
        {
            NavigationItems = navigationItems;
        }

        public IEnumerable<NavigationItemViewModel> NavigationItems { get; private set; }
    }
}
