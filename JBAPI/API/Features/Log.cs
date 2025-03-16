using System;
using System.Net.Sockets;
using System.Text;

namespace JBAPI.API.Features
{
    /// <summary>
    /// 表示一个连接到TCP服务器进行日志记录的日志器。
    /// </summary>
    public class Logger
    {
        public string Header = "[JBAPI LOG]";
        private TcpClient LoggerClient;
        private NetworkStream stream;
        private bool _isInit;

        /// <summary>
        /// 初始化一个新的Logger实例并尝试连接到TCP服务器。
        /// </summary>
        /// <param name="loggerPort">日志服务器监听的端口号。</param>
        public Logger(int loggerPort)
        {
            try
            {
                LoggerClient = new TcpClient("127.0.0.1", loggerPort);
                stream = LoggerClient.GetStream();
                _isInit = true;
            }
            catch (Exception e)
            {
                throw new Exception($"初始化日志器失败: {e.Message}", e);
            }
        }

        /// <summary>
        /// 将消息记录到TCP服务器，并可以选择颜色和是否包含头部信息。
        /// </summary>
        /// <param name="message">要记录的消息。</param>
        /// <param name="color">显示消息的颜色，默认为DarkBlue。</param>
        /// <param name="isHeader">是否在日志消息中包含头部信息，默认为true。</param>
        public void Log(object message, ConsoleColor color = ConsoleColor.DarkBlue, bool isHeader = true)
        {
            if (!_isInit)
            {
                throw new Exception("日志器未初始化");
            }
            try
            {
                string json = isHeader ? $"{Header} {message}" : message.ToString();
                byte[] data = Encoding.UTF8.GetBytes(json);
                stream.WriteAsync(data, 0, data.Length).Wait();
            }
            catch (Exception e)
            {
                throw new Exception($"记录消息失败: {e.Message}", e);
            }
        }
    }

    /// <summary>
    /// 提供使用初始化的日志器实例记录消息的静态方法。
    /// </summary>
    public static class Log
    {
        public static Logger logger;

        /// <summary>
        /// 使用已初始化的日志器实例添加日志消息。
        /// </summary>
        /// <param name="message">要记录的消息。</param>
        public static void AddLog(object message)
        {
            if (logger == null)
            {
                throw new Exception("日志器未初始化");
            }
            logger.Log(message, ConsoleColor.DarkYellow);
        }

        public static void AddDebugLog(object message)
        {
            if (logger == null)
            {
                throw new Exception("日志器未初始化");
            }
            logger.Log(message, ConsoleColor.DarkGray);
        }

        public static void AddErrorLog(object message)
        {
            if (logger == null)
            {
                throw new Exception("日志器未初始化");
            }
            logger.Log(message, ConsoleColor.DarkRed);
        }
    }
}