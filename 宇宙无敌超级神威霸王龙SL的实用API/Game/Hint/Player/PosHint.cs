using Exiled.API.Features;
using JBAPI.Log;
using JBPI.Log;
using MEC;
using RueI.Displays;
using RueI.Elements;
using System.Collections.Generic;

namespace JBAPI.hint
{
    public static class PosRuelHint
    {
        public static class 显示中心
        {
            private static Dictionary<ReferenceHub, Display> 显示 = new Dictionary<ReferenceHub, Display>();

            public static Display GetOrCreateDisplay(ReferenceHub hub)
            {
                if (!显示.ContainsKey(hub))
                {
                     显示[hub] = new Display(hub);
                }
                return 显示[hub];
            }
        }

        /// <summary>
        /// 一个RuelHint的变种，常用于如"bc","经验提示"之类的不允许重叠的Hint
        /// </summary>
        /// <param name="玩家"></param>
        /// <param name="位置"></param>
        /// <param name="文本"></param>
        /// <param name="时间"></param>
        public static void PosHint(this Player 玩家, float 位置, string 文本, int 时间 = 5)
        {
            if (玩家 != null && 玩家.ReferenceHub != null)
            {
                Display 显示 = 显示中心.GetOrCreateDisplay(玩家.ReferenceHub);

                float 向下的位置 = -显示.Elements.Count * 30f;

                SetElement 元素 = new SetElement(位置 + 向下的位置, 文本)
                {
                    Position = 位置 + 向下的位置,
                };

                显示.Elements.Add(元素);

                显示.Update();

                Timing.CallDelayed(时间, () =>
                {
                    显示.Elements.Remove(元素);
                    显示.Update();
                });
            }
        }
    }
}
