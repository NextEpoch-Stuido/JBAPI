namespace JBAPI.Features.Badge.Colorful
{
    using Exiled.API.Features;
    using JBAPI.Features.UnityScript;
    using MEC;

    /// <summary>
    /// 彩色称号
    /// </summary>
    public static class RainbowTagsAPI
    {
        /// <summary>
        /// 存储可用颜色
        /// </summary>
        private static readonly string[] COLORLIST = new[]
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
        /// 彩色称号启用方法
        /// </summary>
        /// <param name="PLAYERS"></param>
        /// <param name="TEXT"></param>
        /// <param name="INTERVAL"></param>
        /// <param name="是否启用"></param>
        public static void RainbowTag(this Player PLAYERS, string TEXT, float INTERVAL, bool 是否启用 = true)
        {
            Timing.CallContinuously(2f, () =>
            {
                PLAYERS.RankName = TEXT;

                if (!是否启用)
                {
                    var _PLAYER = PLAYERS.GameObject.GetComponent<TagController>();
                    if (_PLAYER != null)
                    {
                        UnityEngine.Object.Destroy(_PLAYER);
                    }

                    PLAYERS.RankColor = "red";

                    return;
                }

                var PLAYER = PLAYERS.GameObject.GetComponent<TagController>();


                if (PLAYER == null)
                {
                    PLAYER = PLAYERS.GameObject.AddComponent<TagController>();
                    PLAYER.Colors = COLORLIST;
                    PLAYER.Interval = INTERVAL;
                }

            });
        }
    }
}
