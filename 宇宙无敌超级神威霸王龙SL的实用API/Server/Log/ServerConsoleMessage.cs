namespace JBPI.Log
{
    public static class ServerCC
    {
        /// <summary>
        /// 默认情况下的日志
        /// </summary>
        /// <param name="消息"></param>
        public static void 日志(string 消息)
            => ServerConsole.AddLog(消息, System.ConsoleColor.Cyan);

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="消息"></param>
        public static void 警告(string 消息)
            => ServerConsole.AddLog(消息, System.ConsoleColor.DarkYellow);

        /// <summary>
        /// 调式日志 Debug
        /// </summary>
        /// <param name="消息"></param>
        public static void 调试(string 消息)
            => Exiled.API.Features.Log.Debug(消息);

        /// <summary>
        /// 发生错误时的日志
        /// </summary>
        /// <param name="消息"></param>
        public static void 错误(string 消息)
            => ServerConsole.AddLog($"[错误] {消息}", System.ConsoleColor.Red);

        /// <summary>
        /// 其他日志
        /// </summary>
        /// <param name="消息"></param>
        public static void 其他(string 消息)
            => ServerConsole.AddLog(消息, System.ConsoleColor.Green);

        /// <summary>
        /// 自定义消息
        /// </summary>
        /// <param name="消息"></param>
        /// <param name="颜色"></param>
        public static void 自定义(string 消息, System.ConsoleColor 颜色)
            => ServerConsole.AddLog(消息, 颜色);
    }
}
