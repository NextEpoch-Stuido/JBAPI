// -----------------------------------------------------------------------
// <copyright file="Ruel_Hint.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Hint
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using MEC;
    using RueI.Displays;
    using RueI.Elements;

    /// <summary>
    /// 提供在屏幕上固定显示提示信息的功能.
    /// </summary>
    public static class Ruel_Hint
    {
        /// <summary>
        /// 在指定的玩家屏幕上显示一个提示信息，并在指定时间后自动移除.
        /// </summary>
        /// <param name="player">目标玩家.</param>
        /// <param name="position">提示信息在屏幕上的位置.</param>
        /// <param name="text">提示文本内容.</param>
        /// <param name="time">提示信息显示的持续时间（以秒为单位），默认为 5 秒.</param>
        public static void RuelHint(this Player player, float position, string text, int time = 5)
        {
            if (player != null && player.ReferenceHub != null)
            {
                Display display = DisplayCore.GetOrCreateDisplay(player.ReferenceHub);

                SetElement element = new SetElement(position, text)
                {
                    Position = position,
                };

                display.Elements.Add(element);
                display.Update();

                Timing.CallDelayed(time, () =>
                {
                    display.Elements.Remove(element);
                    display.Update();
                });
            }
        }

        /// <summary>
        /// 提供显示核心的支持功能.
        /// </summary>
        private static class DisplayCore
        {
            /// <summary>
            /// 用于存储与玩家关联的显示实例的字典.
            /// </summary>
            private static readonly Dictionary<ReferenceHub, Display> Displays = new Dictionary<ReferenceHub, Display>();

            /// <summary>
            /// 获取与指定 <see cref="ReferenceHub"/> 关联的 <see cref="Display"/> 实例.
            /// 如果实例不存在，则创建一个新的实例.
            /// </summary>
            /// <param name="hub">与所需显示相关联的 <see cref="ReferenceHub"/>.</param>
            /// <returns>与指定 <paramref name="hub"/> 关联的 <see cref="Display"/> 实例.</returns>
            public static Display GetOrCreateDisplay(ReferenceHub hub)
            {
                if (!Displays.ContainsKey(hub))
                {
                    Displays[hub] = new Display(hub);
                }

                return Displays[hub];
            }
        }
    }
}
