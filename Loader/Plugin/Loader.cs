using JBAPI.API.Config;
using JBAPI.API.Features;
using JBAPI.API.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JBAPI.Loader.Plugin
{
    public static class Loader
    {
        /// <summary>
        /// 构造函数加载
        /// </summary>
        static Loader()
        {
            Log.AddLog("JBAPI 正在加载...");
            Log.AddLog("JBAPI 基于EXILED(2.1.14)开发, 其作者为 Exiled.Team");

            if (!Directory.Exists(Paths.Plugins))
                Directory.CreateDirectory(Paths.Plugins);

            if (!Directory.Exists(Paths.Dependencies))
                Directory.CreateDirectory(Paths.Dependencies);
        }
        public static SortedSet<IPlugin> Plugins { get; } = new SortedSet<IPlugin>(PluginPriorityComparer.Instance);
        public static List<Assembly> Dependencies { get; } = new List<Assembly>();
        public static Dictionary<Assembly, string> Locations { get; } = new Dictionary<Assembly, string>();

        public static void Run(Assembly[]? dependencies = null)
        {
            if (dependencies?.Length > 0)
                Dependencies.AddRange(dependencies);

            LoadDependencies();
            LoadPlugins();

            EnablePlugins();

            // Log.AddLog(); <----此处应写入输出JBAPI版本信息
        }
        public static void EnablePlugins()
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    if (ConfigSystem.GetBoolConfig("IsEnabled", Path.Combine(Paths.Config, $"{plugin.Name}-Config.txt")))
                    {
                        plugin.OnEnabled();
                    }
                }
                catch (Exception exception)
                {
                    Log.AddLog($"Plugin \"{plugin.Name}\" threw an exception while enabling: {exception}");
                }
            }
        }
        public static IPlugin? CreatePlugin(Assembly assembly)
        {
            try
            {
                foreach (Type type in assembly.GetTypes().Where(type => !type.IsAbstract && !type.IsInterface))
                {
                    if (!type.BaseType.IsGenericType || (type.BaseType.GetGenericTypeDefinition() != typeof(JBAPI.API.Plugin.Plugin) && type.BaseType.GetGenericTypeDefinition() != typeof(JBAPI.API.Plugin.Plugin)))
                    {
                        //Log.AddLog($"\"{type.FullName}\" does not inherit from Plugin<TConfig>, skipping.", ShouldDebugBeShown);
                        continue;
                    }

                    //Log.AddLog($"Loading type {type.FullName}", ShouldDebugBeShown);

                    IPlugin? plugin = null;

                    var constructor = type.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        //Log.AddLog("Public default constructor found, creating instance...", ShouldDebugBeShown);

                        plugin = constructor.Invoke(null) as IPlugin;
                    }
                    else
                    {
                        //Log.AddLog($"Constructor wasn't found, searching for a property with the {type.FullName} type...", ShouldDebugBeShown);

                        var value = Array.Find(type.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public), property => property.PropertyType == type)?.GetValue(null);

                        if (value != null)
                            plugin = value as IPlugin;
                    }

                    if (plugin == null)
                    {
                        Log.AddLog($"{type.FullName} is a valid plugin, but it cannot be instantiated! It either doesn't have a public default constructor without any arguments or a static property of the {type.FullName} type!");

                        continue;
                    }

                    //Log.AddLog($"Instantiated type {type.FullName}", ShouldDebugBeShown);


                    return plugin;
                }
            }
            catch (Exception exception)
            {
                Log.AddLog($"Error while initializing plugin {assembly.GetName().Name} (at {assembly.Location})! {exception}");
            }

            return null;
        }
        public static void LoadPlugins()
        {
            foreach (string assemblyPath in Directory.GetFiles(Paths.Plugins, "*.dll"))
            {
                Assembly assembly = LoadAssembly(assemblyPath)!;

                if (assembly == null)
                    continue;

                Locations[assembly] = assemblyPath;

                Log.AddLog($"Loaded plugin {assembly.GetName().Name}@{assembly.GetName().Version.ToString(3)}");
            }

            foreach (Assembly assembly in Locations.Keys)
            {
                if (Locations[assembly].Contains("dependencies"))
                    continue;

                IPlugin plugin = CreatePlugin(assembly)!;

                if (plugin == null)
                    continue;

                Plugins.Add(plugin);
            }
        }
        private static void LoadDependencies()
        {
            try
            {
                foreach (string dependency in Directory.GetFiles(Paths.Dependencies, "*.dll"))
                {
                    Assembly assembly = LoadAssembly(dependency)!;

                    if (assembly == null)
                        continue;

                    Locations[assembly] = dependency;

                    Dependencies.Add(assembly);

                    Log.AddLog($"Loaded dependency {assembly.GetName().Name}@{assembly.GetName().Version.ToString(3)}");
                }

                Log.AddLog("Dependencies loaded successfully!");
            }
            catch (Exception exception)
            {
                Log.AddLog($"An error has occurred while loading dependencies! {exception}");
            }
        }
        public static Assembly? LoadAssembly(string path)
        {
            try
            {
                return Assembly.Load(File.ReadAllBytes(path));
            }
            catch (Exception exception)
            {
                Log.AddLog($"Error while loading an assembly at {path}! {exception}");
            }

            return null;
        }
        public static void DisablePlugins()
        {
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    plugin.OnDisabled();
                }
                catch (Exception exception)
                {
                    Log.AddLog($"Plugin \"{plugin.Name}\" threw an exception while disabling: {exception}");
                }
            }
        }
    }
}
