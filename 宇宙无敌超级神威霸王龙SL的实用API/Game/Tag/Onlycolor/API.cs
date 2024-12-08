using Exiled.API.Features;
using JBPI.Log;
using MEC;

namespace JBAPI.Tag
{
    public static class Onlycolor
    {
        /// <summary>
        /// 这是单色称号的API 您可以对指定的玩家进行添加称号
        /// </summary>
        /// <param name="玩家"></param>
        /// <param name="文本"></param>
        /// <param name="颜色"></param>
        public static void ORTag(this Player 玩家, string 文本, string 颜色)
        {
            Timing.CallContinuously(2f, () =>
            {
                玩家.RankName = 文本;
                玩家.RankColor = 颜色;
                ServerCC.日志($"JBAPI.OnlyColor调用 玩家 {玩家.Nickname} ({玩家.UserId})");
            });
        }
    }
}
