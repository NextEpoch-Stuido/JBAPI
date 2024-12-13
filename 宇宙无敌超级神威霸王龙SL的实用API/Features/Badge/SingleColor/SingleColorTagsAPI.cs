namespace JBAPI.Features.Badge
{
    using Exiled.API.Features;

    /// <summary>
    /// 单色称号
    /// </summary>
    public static class SingleColorTagsAPI
    {
        /// <summary>
        /// 单色称号启用方法
        /// </summary>
        /// <param name="PLAYER"></param>
        /// <param name="COLOR"></param>
        /// <param name="TEXT"></param>
        /// <param name="ISCOVER"></param>
        public static void Tags(this Player PLAYER, string COLOR, string TEXT,bool ISCOVER = true)
        {
            if (ISCOVER == true)
            {
                PLAYER.RankName = TEXT;
                PLAYER.RankColor = COLOR;
            }
        }
    }
}
