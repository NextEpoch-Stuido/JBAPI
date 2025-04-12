using JBAPI.API.Features;
using JBAPI.API.Plugin;
using System.Collections.Generic;

namespace JBAPI.Loader.Plugin
{
    public sealed class PluginPriorityComparer : IComparer<IPlugin>
    {
        public static readonly PluginPriorityComparer Instance = new PluginPriorityComparer();

        /// <inheritdoc/>
        public int Compare(IPlugin x, IPlugin y)
        {
            var value = y.Priority.CompareTo(x.Priority);
            if (value == 0)
                value = x.GetHashCode().CompareTo(y.GetHashCode());

            return value == 0 ? 1 : value;
        }
    }
}