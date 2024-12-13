namespace JBAPI.Features.Log
{
    public static class ServerLog
    {
        /// <summary>
        /// 默认情况下的日志
        /// </summary>
        /// <param name="消息"></param>
        public static void AddLog(string 消息)
            => ServerConsole.AddLog(消息, System.ConsoleColor.Cyan);

        /// <summary>
        /// 发出警告的日志
        /// </summary>
        /// <param name="消息"></param>
        public static void WarnLog(string 消息)
            => ServerConsole.AddLog(消息, System.ConsoleColor.DarkYellow);

        /// <summary>
        /// 发生错误时的日志
        /// </summary>
        /// <param name="消息"></param>
        public static void ErroLog(string 消息)
            => ServerConsole.AddLog($"[错误] {消息}", System.ConsoleColor.Red);

        /// <summary>
        /// 自定义颜色消息
        /// </summary>
        /// <param name="消息"></param>
        /// <param name="颜色"></param>
        public static void CustomLog(string 消息, System.ConsoleColor 颜色)
            => ServerConsole.AddLog(消息, 颜色);
    }
}
