// -----------------------------------------------------------------------
// <copyright file="ServerLog.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Log
{
    /// <summary>
    /// 服务器日志.
    /// </summary>
    public static class ServerLog
    {
        /// <summary>
        /// 默认情况下的日志.
        /// </summary>
        /// <param name="mESSAGE">消息.</param>
        public static void AddLog(string mESSAGE)
            => ServerConsole.AddLog($"[INFO] {mESSAGE}", System.ConsoleColor.Cyan);

        /// <summary>
        /// 发出警告的日志.
        /// </summary>
        /// <param name="mESSAGE">消息.</param>
        public static void WarnLog(string mESSAGE)
            => ServerConsole.AddLog($"[WARN] {mESSAGE}", System.ConsoleColor.DarkYellow);

        /// <summary>
        /// 发生错误时的日志.
        /// </summary>
        /// <param name="mESSAGE">消息.</param>
        public static void ErroLog(string mESSAGE)
            => ServerConsole.AddLog($"[ERRO] {mESSAGE}", System.ConsoleColor.Red);

        /// <summary>
        /// 自定义颜色mESSAGE.
        /// </summary>
        /// <param name="mESSAGE">消息.</param>.
        /// <param name="cOLOR">显示的颜色.</param>
        public static void CustomLog(string mESSAGE, System.ConsoleColor cOLOR)
            => ServerConsole.AddLog(mESSAGE, cOLOR);
    }
}
