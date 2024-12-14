// -----------------------------------------------------------------------
// <copyright file="GameLog.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Log
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// 游戏控制台.
    /// </summary>
    public static class GameLog
    {
        /// <summary>
        /// 一个可以向游戏控制台发送消息的API.
        /// </summary>
        /// <param name="pLAYER">提示的玩家.</param>
        /// <param name="tEXT">发送的文本.</param>
        [Obsolete("请使用Exiled提供的 SendConsoleMessage")]
        public static void ConsleLog(this Player pLAYER, string tEXT)
        {
            pLAYER.SendConsoleMessage(tEXT, string.Empty);
        }
    }
}
