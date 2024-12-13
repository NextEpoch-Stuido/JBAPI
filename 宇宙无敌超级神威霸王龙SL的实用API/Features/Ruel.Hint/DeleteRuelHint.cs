namespace JBAPI.Features.Hint
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using RueI.Displays;

    /// <summary>
    /// 移除Hint
    /// </summary>
    public static class Delete_RuelHint
    {
        /// <summary>
        /// 用于创建显示核心的类.
        /// </summary>
        private static class Display_Core
        {
            /// <summary>
            /// 一个字典，用于储存Hint
            /// </summary>
            private static Dictionary<ReferenceHub, Display> DISPLAY = new Dictionary<ReferenceHub, Display>();

            /// <summary>
            /// 获取与指定的 <see cref="ReferenceHub"/> 相关联的现有 <see cref="Display"/>，
            /// 如果不存在则创建一个新的实例.
            /// </summary>
            /// <param name="hub">与所需的显示相关联的 <see cref="ReferenceHub"/>.</param>
            /// <returns>与指定 <paramref name="hub"/> 相关联的 <see cref="Display"/> 实例.</returns>
            public static Display GetOrCreateDisplay(ReferenceHub HUB)
            {
                if (!DISPLAY.ContainsKey(HUB))
                {
                    DISPLAY[HUB] = new Display(HUB);
                }

                return DISPLAY[HUB];
            }
        }

        /// <summary>
        /// 移除Hint
        /// </summary>
        /// <param name="PLAYER"></param>
        public static void DeleteRuelHint(this Player PLAYER)
        {
            Display DISPLAY = Display_Core.GetOrCreateDisplay(PLAYER.ReferenceHub);

            DISPLAY.Delete();
        }
    }
}
