using Exiled.API.Features;
using System;

namespace JBAPI.Features.Log
{
    public static class GameLog
    {
        /// <summary>
        /// 一个可以向游戏控制台发送消息的API
        /// </summary>
        /// <param name="玩家"></param>
        /// <param name="消息"></param>
        /// <param name="级别"></param>
        [Obsolete("已弃用  请使用Exiled提供的 SendConsoleMessage")]
        public static void ConsleLog(this Player PLAYER, string TEXT)
        {
            PLAYER.SendConsoleMessage(TEXT, "");
        }
    }
}
