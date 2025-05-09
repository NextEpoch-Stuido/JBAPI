using GameSystem.Player;
using JBAPI.API.Config;
using JBAPI.API.Enums;
using JBAPI.API.Interface;
using JBAPI.API.Features.Extension;
using System.Collections.Generic;
using JBAPI.API.Features.Interface;

namespace JBAPI.API.Features
{
    public sealed class Player : IPlayer, IWapper<PlayerHub>
    {
        public static IReadOnlyCollection<PlayerHub> AllPlayers => PlayerHub.AllHubs;
        public Player(PlayerHub hub)
        {
            if (!Extensions.IsNull(hub))
                Base = hub;
            else
                throw new System.NullReferenceException("Player not found");
        }
        public Player(int id)
        {
            var hub = PlayerHub.Get(id);
            if (!Extensions.IsNull(hub))
                Base = hub;
            else
                throw new System.NullReferenceException("Player not found");
        }
        public Player(string Steam64)
        {
            var hub = PlayerHub.Get(Steam64);
            if (!Extensions.IsNull(hub))
                Base = hub;
            else
                throw new System.NullReferenceException("Player not found");
        }
        public static Player Get(int id) => new Player(id);
        public static Player Get(string Steam64) => new Player(Steam64);
        public static Player Get(PlayerHub hub) => new Player(hub);
        public static Player Get(Player player) => new Player(player.Base);
        public PlayerHub Base { get; }
        public float MaxHealth { get => Base.maxHealth; set => Base.maxHealth = value; }
        public float Health { get => Base.health; set => Base.health = value; }
        private NicknameSync NicknameSync => Base.nicknameSync;
        public string Nickname => NicknameSync.Nickname;
        public string DisplayGlobalBadge => NicknameSync.DisplayGlobalBadge;
        public string DisplayLocalInfoBadge => NicknameSync.DisplayLocalInfoBadge;
        public Inventory Inventory => Base.inventory;
    }
}