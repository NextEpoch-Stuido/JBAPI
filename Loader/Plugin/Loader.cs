using JBAPI.API.Config;
using JBAPI.API.Features;
using JBAPI.API.Plugin;
using JBAPI.Events;
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
        /// 框架初始化
        /// </summary>
        static Loader()
        {
            Log.AddLog("JBAPI 正在加载...");
            Log.AddLog("JBAPI加载完毕 (JBAPI基于EXILED开发, 其作者为 Exiled.Team)");

            if (!Directory.Exists(Paths.Plugins))
                Directory.CreateDirectory(Paths.Plugins);

            if (!Directory.Exists(Paths.Dependencies))
                Directory.CreateDirectory(Paths.Dependencies);
        }
        public static SortedSet<IPlugin> Plugins { get; } = new SortedSet<IPlugin>(PluginPriorityComparer.Instance);
        public static List<Assembly> Dependencies { get; } = new List<Assembly>();
        public static Dictionary<Assembly, string> Locations { get; } = new Dictionary<Assembly, string>();

        /// <summary>
        /// 开始加载插件
        /// </summary>
        /// <param name="dependencies">引用</param>
        public static void Run(Assembly[]? dependencies = null)
        {
            if (dependencies?.Length > 0)
                Dependencies.AddRange(dependencies);

            LoadDependencies();
            LoadPlugins();

            EnablePlugins();

            // Log.AddLog(); <----TODO: JBAPI版本
        }

        /// <summary>
        /// 启用插件与事件中心
        /// </summary>
        public static void EnablePlugins()
        {
            EventLoader.RegEvents();
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
                    Log.AddErrorLog($"插件 \"{plugin.Name}\" 在启用时发生了错误: {exception}");
                }
            }
        }

        /// <summary>
        /// 创建插件实例
        /// </summary>
        /// <param name="assembly">插件程序集 </param>
        /// <returns>插件实例</returns>
        public static IPlugin? CreatePlugin(Assembly assembly)
        {
            try
            {
                foreach (Type type in assembly.GetTypes().Where(type => !type.IsAbstract && !type.IsInterface))
                {
                    if (!type.BaseType.IsGenericType || (type.BaseType.GetGenericTypeDefinition() != typeof(API.Plugin.Plugin) && type.BaseType.GetGenericTypeDefinition() != typeof(API.Plugin.Plugin)))
                    {
                        Log.AddLog($"\"{type.FullName}\" 非正确的插件, 跳过加载"); // Debug
                        continue;
                    }

                    Log.AddDebugLog($"加载类型 {type.FullName}"); // Debug

                    IPlugin? plugin = null;

                    var constructor = type.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        Log.AddDebugLog("找到构造函数，正在创建实例..."); // Debug

                        plugin = constructor.Invoke(null) as IPlugin;
                    }
                    else
                    {
                        Log.AddDebugLog($"找不到构造函数，请搜索具有 {type.FullName} 类型..."); // Debug

                        var value = Array.Find(type.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public), property => property.PropertyType == type)?.GetValue(null);

                        if (value != null)
                            plugin = value as IPlugin;
                    }

                    if (plugin == null)
                    {
                        Log.AddLog($"{type.FullName}是一个有效的插件，但不能被加载! JBAPI无法获取插件的实例!");

                        continue;
                    }

                    Log.AddDebugLog($"实例化类型 {type.FullName}"); // Debug


                    return plugin;
                }
            }
            catch (Exception exception)
            {
                Log.AddErrorLog($"初始化插件出现错误 {assembly.GetName().Name} (在 {assembly.Location} 处)! {exception}");
            }

            return null;
        }

        /// <summary>
        /// 加载插件
        /// </summary>
        public static void LoadPlugins()
        {
            foreach (string assemblyPath in Directory.GetFiles(Paths.Plugins, "*.dll"))
            {
                Assembly assembly = LoadAssembly(assemblyPath)!;

                if (assembly == null)
                    continue;

                Locations[assembly] = assemblyPath;

                Log.AddLog($"加载插件 {assembly.GetName().Name}@{assembly.GetName().Version.ToString(3)}");
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

        /// <summary>
        /// 加载依赖
        /// </summary>
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

                    Log.AddLog($"加载依赖 {assembly.GetName().Name}@{assembly.GetName().Version.ToString(3)}");
                }

                Log.AddLog("依赖加载完成!");
            }
            catch (Exception exception)
            {
                Log.AddErrorLog($"在加载依赖时发生错误! {exception}");
            }
        }

        /// <summary>
        /// 加载程序集
        /// </summary>
        /// <param name="path">程序集路径</param>
        /// <returns>程序集实例</returns>
        public static Assembly? LoadAssembly(string path)
        {
            try
            {
                return Assembly.Load(File.ReadAllBytes(path));
            }
            catch (Exception exception)
            {
                Log.AddErrorLog($"在 {path} 加载程序集时发生错误! {exception}");
            }

            return null;
        }

        /// <summary>
        /// 禁用插件与事件中心
        /// </summary>
        public static void DisablePlugins()
        {
            EventLoader.UnregEvents();
            foreach (IPlugin plugin in Plugins)
            {
                try
                {
                    plugin.OnDisabled();
                }
                catch (Exception exception)
                {
                    Log.AddErrorLog($"插件 \"{plugin.Name}\" 在关闭时报错: {exception}");
                }
            }
        }
    }
}
