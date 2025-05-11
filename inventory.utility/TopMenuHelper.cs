using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace inventory.utility
{
    public static class TopMenuHelper
    {
        public class NavigationItem
        {
            public string? PageName { get; set; }
            public string? ControllerName { get; set; }
            public string? ActionName { get; set; }
            public string? Path { get; set; }
        }
        public static List<NavigationItem> GetNavigationItems()
        {
            var navigationItems = new List<NavigationItem>();

            // Get all nested classes in TopMenu
            var nestedClasses = typeof(TopMenu).GetNestedTypes(BindingFlags.Public | BindingFlags.Static);

            foreach (var nestedClass in nestedClasses)
            {
                var pageName = nestedClass.GetField("PageName")?.GetValue(null)?.ToString();
                var controllerName = nestedClass.GetField("ControllerName")?.GetValue(null)?.ToString();
                var actionName = nestedClass.GetField("ActionName")?.GetValue(null)?.ToString();
                var path = nestedClass.GetField("Path")?.GetValue(null)?.ToString();

                if (!string.IsNullOrEmpty(pageName) && !string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(actionName))
                {
                    navigationItems.Add(new NavigationItem
                    {
                        PageName = pageName,
                        ControllerName = controllerName,
                        ActionName = actionName,
                        Path = path
                    });
                }
            }

            return navigationItems;
        }
    }
}
