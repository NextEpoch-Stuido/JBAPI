// -----------------------------------------------------------------------
// <copyright file="PrmanentDisplay_RuelHint.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Hint
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using RueI.Displays;
    using RueI.Elements;

    /// <summary>
    /// 永久显示的Hint.
    /// </summary>
    public static class PrmanentDisplay_RuelHint
    {
        /// <summary>
        /// 在指定的玩家屏幕上显示一个永久时间的提示信息.
        /// </summary>
        /// <param name="pLAYER">要显示提示信息的目标玩家.</param>
        /// <param name="pOSITION">提示信息在屏幕上的位置.</param>
        /// <param name="tEXT">要显示的提示文本内容.</param>
        public static void AllTimeHint(this Player pLAYER, float pOSITION, string tEXT)
        {
            if (pLAYER != null && pLAYER.ReferenceHub != null)
            {
                Display dISPLAY = Display_Core.GetOrCreateDisplay(pLAYER.ReferenceHub);

                SetElement eLEMENT = new SetElement(pOSITION, tEXT)
                {
                    Position = pOSITION,
                };

                dISPLAY.Elements.Add(eLEMENT);

                dISPLAY.Update();
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
