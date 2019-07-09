using Aspire.Navigation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspire.Navigation.ViewComponents
{
    public class Navigation : ViewComponent
    {
        public Navigation()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Change this to get the nav items from the Navigation folder class or DB?
            var navigationItems = new[]
            {
                new NavigationItemViewModel("Check In", "/Home/UnderConstruction"),
                new NavigationItemViewModel("Create Schedule", "/Home/UnderConstruction"),
                new NavigationItemViewModel("Contact Update", "/Home/UnderConstruction"),
                new NavigationItemViewModel("My Profile", "/Home/UnderConstruction"),
                new NavigationItemViewModel("Instruments", "/Instruments/Create"),
                new NavigationItemViewModel("Director Landing", "/Director/UnderConstruction"),
            };

            var model = new NavigationViewModel(navigationItems);

            return View(model);
        }
    }
}
