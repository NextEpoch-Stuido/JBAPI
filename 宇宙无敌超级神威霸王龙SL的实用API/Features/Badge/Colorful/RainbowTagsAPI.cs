// -----------------------------------------------------------------------
// <copyright file="RainbowTagsAPI.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.Badge
{
    using Exiled.API.Features;
    using JBAPI.Features.UnityScript;
    using MEC;

    /// <summary>
    /// 彩色称号.
    /// </summary>
    public static class RainbowTagsAPI
    {
        /// <summary>
        /// 存储可用颜色.
        /// </summary>
        private static readonly string[] COLORLIST = new[]
        {
            "pink",
            "red",
            "brown",
            "silver",
            "light_green",
            "crimson",
            "cyan",
            "aqua",
            "deep_pink",
            "tomato",
            "yellow",
            "magenta",
            "blue_green",
            "orange",
            "lime",
            "green",
            "emerald",
            "carmine",
            "nickel",
            "mint",
            "army_green",
            "pumpkin",
        };

        /// <summary>
        /// 彩色称号启用方法.
        /// </summary>
        /// <param name="pLAYERS">给予彩称的玩家.</param>
        /// <param name="tEXT">显示的文本.</param>
        /// <param name="iNTERVAL">频率.</param>
        /// <param name="iSENABLED">是否启用彩称.</param>
        public static void RainbowTag(this Player pLAYERS, string tEXT, float iNTERVAL, bool iSENABLED = true)
        {
            Timing.CallContinuously(2f, () =>
            {
                pLAYERS.RankName = tEXT;

                if (!iSENABLED)
                {
                    var pLAYER = pLAYERS.GameObject.GetComponent<TagController>();
                    if (pLAYER != null)
                    {
                        UnityEngine.Object.Destroy(pLAYER);
                    }

                    pLAYERS.RankColor = "red";

                    return;
                }

                var xPLAYER = pLAYERS.GameObject.GetComponent<TagController>();

                if (xPLAYER == null)
                {
                    xPLAYER = pLAYERS.GameObject.AddComponent<TagController>();
                    xPLAYER.Colors = COLORLIST;
                    xPLAYER.Interval = iNTERVAL;
                }
            });
        }
    }
}
