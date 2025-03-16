using System;
using System.IO;

namespace JBAPI.API.Features
{
    public static class Paths
    {
        static Paths() => Reload();

        /// <summary>
        /// 游戏文件依赖
        /// </summary>
        public static string ManagedAssemblies { get; } = Path.Combine(Path.Combine(Environment.CurrentDirectory, "SiteWinter_Data"), "Managed");

        /// <summary>
        /// 插件文件夹
        /// </summary>
        public static string PluginFile { get; } = Directory.GetParent(Path.Combine(Environment.CurrentDirectory, "SiteWinter_Data")).FullName;

        /// <summary>
        /// 配置文件
        /// </summary>
        public static string? Config = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SiteWinter", "PluginConfig");

        /// <summary>
        /// 插件
        /// </summary>
        public static string? Plugins { get; set; }

        /// <summary>
        /// 依赖文件夹
        /// </summary>
        public static string? Dependencies { get; set; }

        /// <summary>
        /// 加载插件与依赖文件夹
        /// </summary>
        public static void Reload()
        {
            Plugins = Path.Combine(PluginFile, "Plugins");
            Dependencies = Path.Combine(Plugins, "dependencies");
            Config = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SiteWinter", "PluginConfig");
        }
    }
}
