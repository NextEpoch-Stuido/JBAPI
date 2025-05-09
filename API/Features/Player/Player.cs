using GameSystem.Player;
using JBAPI.API.Interface;
using System.Collections.Generic;
using JBAPI.API.Features.Interface;
using GameSystem.Enum;
using GameSystem.ItemSystem;
using Mirror;
using UnityEngine;
using Extensions = JBAPI.API.Features.Extension.Extensions;
using GameSystem.RoleSystem;

namespace JBAPI.API.Features
{
    public sealed class Player : IPlayer, IWapper<PlayerHub>
    {
        public static IReadOnlyList<Player> List
        {
            get
            {
                var list = new List<Player>();
                foreach (var i in PlayerHub.AllHubs)
                {
                    list.Add(new Player(i));
                }
                return list;
            }
        }
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
        public string UserId => Base.Networksteam64Id;
        public float MaxHealth { get => Base.maxHealth; set => Base.maxHealth = value; }
        public float Health { get => Base.health; set => Base.health = value; }
        public string Nickname => NicknameSync.Nickname;
        public string DisplayGlobalBadge => NicknameSync.DisplayGlobalBadge;
        public string DisplayLocalInfoBadge => NicknameSync.DisplayLocalInfoBadge;
        public int Id => Base.Networkid;
        public int Ping => Base.Ping;
        public PlayerHub Base { get; }
        public Inventory Inventory => Base.inventory;
        public GameObject GameObject => Base.gameObject;
        private NicknameSync NicknameSync => Base.nicknameSync;
        public Role Role => Base.role;
        public IReadOnlyList<ItemBase> Items => Inventory.Items;
        public void Kill() => Hurt(Health + 1);
        public void Hurt(float num) => Base.Damaged(num);
        public void Heal(float num) => Base.Damaged(-num);
        public void Kick(string reason, string title = "你已被服务器封禁!") => Base.Kick(reason, title);
        public void Popup(string title, string content) => Base.Popup(title, content);
        public void SetRole(RoleType type) => Role.Set(type);
        public void ClearItems(bool isDestroy = true)
        {
            foreach (var i in Items)
            {
                Inventory.RemoveItem(i);
                if (isDestroy)
                    NetworkServer.Destroy(i.gameObject);
            }
        }
        public void ClearItems(ItemType type, bool isDestroy = true)
        {
            foreach (var i in Items)
            {
                if (i.Type != type)
                    continue;
                Inventory.RemoveItem(i);
                if (isDestroy)
                    NetworkServer.Destroy(i.gameObject);
            }
        }
        public void AddItem(ItemBase @base) => Inventory.AddItem(@base);
        public bool RemoveItem(ItemType type)
        {
            foreach (var i in Items)
            {
                if (i.Type == type)
                {
                    Inventory.RemoveItem(i);
                    return true;
                }
            }
            return false;
        }
    }
}
