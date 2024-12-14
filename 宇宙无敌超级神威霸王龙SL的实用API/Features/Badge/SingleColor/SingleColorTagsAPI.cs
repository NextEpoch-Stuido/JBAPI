// -----------------------------------------------------------------------
// <copyright file="SingleColorTagsAPI.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Badge
{
    using Exiled.API.Features;

    /// <summary>
    /// 单色称号.
    /// </summary>
    public static class SingleColorTagsAPI
    {
        /// <summary>
        /// 单色称号启用方法.
        /// </summary>
        /// <param name="pLAYER">给予彩称的玩家.</param>
        /// <param name="cOLOR">称号颜色.</param>
        /// <param name="tEXT">称号文本.</param>
        /// <param name="iSCOVER">是否覆盖.</param>
        public static void Tags(this Player pLAYER, string cOLOR, string tEXT, bool iSCOVER = true)
        {
            if (iSCOVER == true)
            {
                pLAYER.RankName = tEXT;
                pLAYER.RankColor = cOLOR;
            }
        }
    }
}
