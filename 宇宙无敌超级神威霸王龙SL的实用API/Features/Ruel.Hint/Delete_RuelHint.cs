// -----------------------------------------------------------------------
// <copyright file="Delete_RuelHint.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Hint
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using RueI.Displays;

    /// <summary>
    /// 移除Hint.
    /// </summary>
    public static class Delete_RuelHint
    {
        /// <summary>
        /// 移除Hint.
        /// </summary>
        /// <param name="pLAYER">指定删除Hint的玩家.</param>
        public static void DeleteRuelHint(this Player pLAYER)
        {
            Display dISPLAY = Display_Core.GetOrCreateDisplay(pLAYER.ReferenceHub);

            dISPLAY.Delete();
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
