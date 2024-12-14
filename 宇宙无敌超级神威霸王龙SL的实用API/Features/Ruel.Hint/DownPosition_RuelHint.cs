// -----------------------------------------------------------------------
// <copyright file="DownPosition_RuelHint.cs" company="JBAPI-Team">
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
    /// 在上一条Hint的下方.
    /// </summary>
    public static class DownPosition_RuelHint
    {
        /// <summary>
        /// 在指定的玩家屏幕上显示一个提示信息，它会在上一条Hint的下方显示，并在指定时间后自动移除.
        /// </summary>
        /// <param name="pLAYER">要显示提示信息的目标玩家.</param>
        /// <param name="pOSITION">提示信息在屏幕上的位置.</param>
        /// <param name="tEXT">要显示的提示文本内容.</param>
        /// <param name="tIME">提示信息显示的持续时间（以秒为单位），默认为 5 秒.</param>
        public static void PosHint(this Player pLAYER, float pOSITION, string tEXT, int tIME = 5)
        {
            if (pLAYER != null && pLAYER.ReferenceHub != null)
            {
                Display dISPLAY = Display_Core.GetOrCreateDisplay(pLAYER.ReferenceHub);

                float dOWN_POSITION = dISPLAY.Elements.Count * 30f;

                SetElement eLEMENT = new SetElement(pOSITION + dOWN_POSITION, tEXT)
                {
                    Position = pOSITION + dOWN_POSITION,
                };

                dISPLAY.Elements.Add(eLEMENT);

                dISPLAY.Update();

                Timing.CallDelayed(tIME, () =>
                {
                    dISPLAY.Elements.Remove(eLEMENT);
                    dISPLAY.Update();
                });
            }
        }

        /// <summary>
        /// 用于创建显示核心的类.
        /// </summary>
        private static class Display_Core
        {
            /// <summary>
            /// 一个字典，用于储存Hint.
            /// </summary>
            private static Dictionary<ReferenceHub, Display> dISPLAY = new Dictionary<ReferenceHub, Display>();

            /// <summary>
            /// 获取与指定的 <see cref="ReferenceHub"/> 相关联的现有 <see cref="Display"/>，
            /// 如果不存在则创建一个新的实例.
            /// </summary>
            /// <param name="hUB">与所需的显示相关联的 <see cref="ReferenceHub"/>.</param>
            /// <returns>与指定 <paramref name="hUB"/> 相关联的 <see cref="Display"/> 实例.</returns>
            public static Display GetOrCreateDisplay(ReferenceHub hUB)
            {
                if (!dISPLAY.ContainsKey(hUB))
                {
                    dISPLAY[hUB] = new Display(hUB);
                }

                return dISPLAY[hUB];
            }
        }
    }
}
