// -----------------------------------------------------------------------
// <copyright file="RandomRolePlayer.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.CustomRole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using JBAPI.Features.Log;
    using PlayerRoles;

    /// <summary>
    /// 这是一个适用于用事件创建一个角色的API，他十分的高效.
    /// </summary>
    public static class RandomRolePlayer
    {
        /// <summary>
        /// 随机选取指定角色的玩家.
        /// </summary>
        /// <param name="rOLE">需要随机选择的玩家角色.</param>
        /// <param name="sKIPBADGE">如果需要跳过某些角色，可输入他的称号.</param>
        /// <param name="iSENABLELOG">是否启用日志.</param>
        /// <returns>返回选取的玩家，否则为null.</returns>
        public static Player RandomSelectPlayer(RoleTypeId rOLE, List<string> sKIPBADGE, bool iSENABLELOG)
        {
            var pLAYER = Player.List.Where(p => p.Role == rOLE).ToList();
            var sELECTPLAYER = pLAYER.Where(p => !sKIPBADGE.Any(rankName => p.DisplayNickname.Contains(rankName))).ToList();

            if (sELECTPLAYER.Any())
            {
                var fINALLYSELECTPLAYER = sELECTPLAYER[new Random().Next(sELECTPLAYER.Count)];

                if (iSENABLELOG)
                {
                    ServerLog.AddLog($"[JB_随机选取] 成功选取到玩家 {fINALLYSELECTPLAYER.Nickname} (Steam64ID: {fINALLYSELECTPLAYER.UserId})");
                }

                return fINALLYSELECTPLAYER;
            }

            if (iSENABLELOG)
            {
                ServerLog.AddLog($"[JB_随机选取] 未成功选取玩家");
            }

            return null;
        }
    }
}
