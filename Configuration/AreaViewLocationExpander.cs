using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace Aspire.Configuration
{
    public class AreaViewLocationExpander : IViewLocationExpander
    {
        private const string _actionName = "{0}";
        private const string _controllerName = "{1}";
        //private const string _areaName = "{2}";

        private static readonly string[] _searchPaths =
        {
            $"~/Areas/{_controllerName}/Views/{_actionName}.cshtml",
            $"~/Areas/Shared/Views/{_actionName}.cshtml",
            $"~/Areas/Shared/Views/Home/{_actionName}.cshtml",
            $"~/Areas/Shared/Views/Shared/Components/{_actionName}.cshtml",
            $"~/Areas/Shared/Views/Shared/{_actionName}.cshtml"
        };

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return _searchPaths;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Intentionally left blank.
        }
    }
}
