using JBAPI.API.Features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace JBAPI.API.Config
{
    /// <summary>
    /// 负责管理配置文件的类，包括初始化、添加、修改和访问配置
    /// </summary>
    public class ConfigSystem
    {
        /// <summary>
        /// 添加配置项到指定配置文件。如果文件不存在则创建文件；如果配置已存在，跳过添加。(获取自己插件的名称 {Assembly.GetName().Name} )
        /// </summary>
        /// <param name="configName">配置的名称。</param>
        /// <param name="configValue">配置的值。</param>
        /// <param name="configFilePath">配置文件的路径（如果为空则使用默认路径）。</param>
        /// <param name="configComment">配置的注释（可选）。</param>
        public static void AddConfig(string configName, object configValue, string configFilePath, string? configComment = null)
        {
            if (!Path.IsPathRooted(configFilePath))
            {
                configFilePath = Path.Combine(Paths.Config, configFilePath);
            }

            string directory = Path.GetDirectoryName(configFilePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(configFilePath))
            {
                File.Create(configFilePath).Close();
            }

            List<string> configLines = new List<string>(File.ReadAllLines(configFilePath));

            foreach (string line in configLines)
            {
                if (line.TrimStart().StartsWith("-")) continue;

                if (line.StartsWith($"{configName} ="))
                {
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(configComment))
            {
                string[] comments = configComment.Split(new[] { "\n" }, StringSplitOptions.None);
                foreach (string comment in comments)
                {
                    configLines.Add($"- {comment}");
                }
            }

            configLines.Add($"{configName} = {configValue};");

            File.WriteAllLines(configFilePath, configLines.ToArray());
        }

        /// <summary>
        /// 修改配置文件中的配置项。
        /// </summary>
        /// <param name="modifyName">是否修改配置的名称。</param>
        /// <param name="oldConfigName">当前配置的名称。</param>
        /// <param name="newConfigValue">新的配置值。</param>
        /// <param name="configFilePath">配置文件的路径（如果为空则使用默认路径）。</param>
        /// <param name="newConfigName">新的配置名称（仅当修改名称时需要）。</param>
        public static void SetConfig(bool modifyName, string oldConfigName, object newConfigValue, string configFilePath, string? newConfigName = null)
        {
            if (!Path.IsPathRooted(configFilePath))
            {
                configFilePath = Path.Combine(Paths.Config, configFilePath);
            }

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"配置文件 {configFilePath} 不存在！");
            }

            List<string> configLines = new List<string>(File.ReadAllLines(configFilePath));
            bool configFound = false;

            for (int i = 0; i < configLines.Count; i++)
            {
                if (configLines[i].TrimStart().StartsWith("-")) continue;

                if (configLines[i].StartsWith($"{oldConfigName} ="))
                {
                    configFound = true;

                    if (modifyName && !string.IsNullOrEmpty(newConfigName))
                    {
                        configLines[i] = $"{newConfigName} = {newConfigValue};";
                    }
                    else
                    {
                        configLines[i] = $"{oldConfigName} = {newConfigValue};";
                    }
                    break;
                }
            }

            if (!configFound)
            {
                throw new KeyNotFoundException($"未找到配置项 {oldConfigName}。");
            }

            File.WriteAllLines(configFilePath, configLines.ToArray());
        }

        /// <summary>
        /// 读取配置值，支持指定路径。
        /// </summary>
        private static string? GetConfigValue(string configName, string configFilePath)
        {
            if (!Path.IsPathRooted(configFilePath))
            {
                configFilePath = Path.Combine(Paths.Config, configFilePath);
            }

            if (!File.Exists(configFilePath))
            {
                File.Create(configFilePath).Close();
                return null;
            }

            string[] configLines = File.ReadAllLines(configFilePath);

            foreach (string line in configLines)
            {
                if (line.TrimStart().StartsWith("-")) continue;

                if (line.StartsWith($"{configName} ="))
                {
                    string[] parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim().TrimEnd(';');
                    }
                }
            }

            throw new KeyNotFoundException($"未找到配置项 {configName}。");
        }

        /// <summary>
        /// 获取配置-int
        /// </summary>
        /// <param name="configName">配置名</param>
        /// <param name="configFilePath">配置路径</param>
        /// <returns>返回类型为int的配置值</returns>
        public static int GetIntConfig(string configName, string configFilePath)
        {
            string configValue = GetConfigValue(configName, configFilePath)!;

            if (int.TryParse(configValue, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException($"配置项 {configName} 的值无法解析为整数。");
            }
        }

        /// <summary>
        /// 获取配置-float
        /// </summary>
        /// <param name="configName">配置名</param>
        /// <param name="configFilePath">配置路径</param>
        /// <returns>返回类型为float的配置值</returns>
        public static float GetFloatConfig(string configName, string configFilePath)
        {
            string configValue = GetConfigValue(configName, configFilePath)!;

            if (float.TryParse(configValue, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException($"配置项 {configName} 的值无法解析为浮点数。");
            }
        }

        /// <summary>
        /// 获取配置-String
        /// </summary>
        /// <param name="configName">配置名</param>
        /// <param name="configFilePath">配置路径</param>
        /// <returns>返回类型为String的配置值</returns>
        public static string GetStringConfig(string configName, string configFilePath)
        {
            return GetConfigValue(configName, configFilePath)!;
        }

        /// <summary>
        /// 获取配置-bool
        /// </summary>
        /// <param name="configName">配置名</param>
        /// <param name="configFilePath">配置路径</param>
        /// <returns>返回类型为bool的配置值</returns>
        public static bool GetBoolConfig(string configName, string configFilePath)
        {
            string configValue = GetConfigValue(configName, configFilePath)!;

            if (bool.TryParse(configValue, out bool result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException($"配置项 {configName} 的值无法解析为布尔值（true 或 false）。");
            }
        }
    }
}
