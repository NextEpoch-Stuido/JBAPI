using Exiled.API.Features;
using static JBAPI.Log.Level;

namespace JBAPI.Log
{
    public static class GameCC
    {
    /// <summary>
    /// 一个可以向游戏控制台发送消息的API
    /// </summary>
    /// <param name="玩家"></param>
    /// <param name="消息"></param>
    /// <param name="级别"></param>
        public static void 控制台消息(this Player 玩家, string 消息, ConsoleLevel 级别)
        {
            string 前缀 = _级别(级别);
            string 颜色 = _颜色(级别);

            玩家.SendConsoleMessage($"<color={颜色}>{前缀}</color>{消息}", "");
        }

        private static string _级别(ConsoleLevel 级别)
        {
            switch (级别)
            {
                case ConsoleLevel.消息:
                    return "[消息] ";
                case ConsoleLevel.警告:
                    return "[警告] ";
                case ConsoleLevel.错误:
                    return "[错误] ";
                case ConsoleLevel.自定义:
                    return "";
                default:
                    return "";
            }
        }

        private static string _颜色(ConsoleLevel 级别)
        {
            switch (级别)
            {
                case ConsoleLevel.消息:
                    return "#a2a2a2";
                case ConsoleLevel.警告:
                    return "yellow";
                case ConsoleLevel.错误:
                    return "red";
                default:
                    return "";
            }
        }
    }
}
