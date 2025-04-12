using JBAPI.API.Config;
using JBAPI.API.Enums;
using JBAPI.API.Features;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace JBAPI.API.Plugin
{
    public abstract class Plugin : IPlugin
    {
        public Plugin()
        {
            Assembly = Assembly.GetCallingAssembly();
            Name = Assembly.GetName().Name;
            Author = Assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            Version = Assembly.GetName().Version;
        }

        public Assembly Assembly { get; protected set; }

        public virtual string Name { get; }

        public virtual string Author { get; }

        public virtual Version Version { get; }
        public virtual PluginPriority Priority { get; }

        public virtual void OnEnabled()
        {
            var attribute = Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Log.AddLog($"由{Author}制作的{Name} (v{(attribute == null ? $"{Version.Major}.{Version.Minor}.{Version.Build})" : attribute.InformationalVersion)} 已加载");
            ConfigSystem.AddConfig($"IsEnabled", true, Path.Combine(Paths.Config, $"{Name}-Config.txt")!, "是否开启插件");
        }

        public virtual void OnDisabled()
        {
            Log.AddLog($"{Name} 已关闭!");
        }
    }
}