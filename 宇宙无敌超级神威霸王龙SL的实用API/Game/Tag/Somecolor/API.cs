using Exiled.API.Features;
using UnityEngine;
using JBAPI.UnityScript;
using JBPI.Log;
using MEC;

namespace JBAPI.Tag
{
    public static class somecolor
    {
        /// <summary>
        /// 存储可用颜色
        /// </summary>
        private static readonly string[] 颜色 = new[]
        {
            "pink", "red", "brown", "silver",
            "light_green", "crimson", "cyan",
            "aqua","deep_pink","tomato",
            "yellow","magenta","blue_green",
            "orange","lime","green",
            "emerald","carmine","nickel",
              "mint","army_green","pumpkin"
        };
        /// <summary>
        /// 彩色称号，您可以给予指定玩家一个可以不断变换颜色的称号
        /// </summary>
        /// <param name="玩家"></param>
        /// <param name="文本"></param>
        /// <param name="频率"></param>
        /// <param name="是否启用"></param>
        public static void RTag(this Player 玩家, string 文本, int 频率, bool 是否启用)
        {
            Timing.CallContinuously(2f, () =>
            {
                玩家.RankName = 文本;

                if (!是否启用)
                {
                    var 神威 = 玩家.GameObject.GetComponent<TagController>();
                    if (神威 != null)
                    {
                        Object.Destroy(神威);
                    }

                    玩家.RankColor = "red";

                    return;
                }

                var 霸王龙 = 玩家.GameObject.GetComponent<TagController>();

                ServerCC.日志($"JBAPI.somecolor调用 玩家 {玩家.Nickname} ({玩家.UserId})");
                

                if (霸王龙 == null)
                {
                    霸王龙 = 玩家.GameObject.AddComponent<TagController>();
                    霸王龙.Colors = 颜色;
                    霸王龙.Interval = 频率;//孩子，时间越快服务器越容易崩，如果你改了，服务器爆炸概不负责
                }

            });
        }
    }
}
