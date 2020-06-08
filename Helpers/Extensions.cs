using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var i in enumerable)
            {
                action(i);
            }

            return enumerable;
        }

        public static string ToListViewItemName(this string routeName)
        {
            return !routeName.Contains(" ") ? routeName : string.Join("_", routeName.Split(' '));
        }

        public static string ToRouteName(this string listViewItemName)
        {
            return !listViewItemName.Contains("_") ? listViewItemName : string.Join(" ", listViewItemName.Split('_'));
        }
    }
}
