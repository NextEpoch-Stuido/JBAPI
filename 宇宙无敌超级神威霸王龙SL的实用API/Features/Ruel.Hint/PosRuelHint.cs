namespace JBAPI.Features.Hint
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using MEC;
    using RueI.Displays;
    using RueI.Elements;

    /// <summary>
    /// 在上一条Hint的下方
    /// </summary>
    public static class DownPosition_RuelHint
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
        /// 在指定的玩家屏幕上显示一个提示信息，它会在上一条Hint的下方显示，并在指定时间后自动移除.
        /// </summary>
        /// <param name="PLAYER">要显示提示信息的目标玩家.</param>
        /// <param name="POSITION">提示信息在屏幕上的位置.</param>
        /// <param name="TEXT">要显示的提示文本内容.</param>
        /// <param name="TIME">提示信息显示的持续时间（以秒为单位），默认为 5 秒.</param>
        public static void PosHint(this Player PLAYER, float POSITION, string TEXT, int TIME = 5)
        {
            if (PLAYER != null && PLAYER.ReferenceHub != null)
            {
                Display DISPLAY = Display_Core.GetOrCreateDisplay(PLAYER.ReferenceHub);

                float DOWN_POSITION = DISPLAY.Elements.Count * 30f;

                SetElement ELEMENT = new SetElement(POSITION + DOWN_POSITION, TEXT)
                {
                    Position = POSITION + DOWN_POSITION,
                };

                DISPLAY.Elements.Add(ELEMENT);

                DISPLAY.Update();

                Timing.CallDelayed(TIME, () =>
                {
                    DISPLAY.Elements.Remove(ELEMENT);
                    DISPLAY.Update();
                });
            }
        }
    }
}
