using GameSystem.Enum;
using GameSystem.ItemSystem;
using JBAPI.API.Features.Interface;
using JBAPI.API.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAPI.API.Features
{
    public class Item : IItem,IWapper<ItemBase>
    {
        public Item(ItemBase baseItem)
        {
            Base = baseItem;
        }
        public Player Owner { get => new Player(Base.Owner); }
        public ItemBase Base { get; }

        /// <summary>
        /// 给予玩家物品
        /// Give player item
        /// </summary>
        /// <param name="player">玩家</param>
        /// <param name="item">物品实例</param>
        public static void GiveItem(Player player, Item item)
        {
            player.Inventory.AddItem(item.Base);
        }
        /// <summary>
        /// 给予玩家物品
        /// Give player item
        /// </summary>
        /// <param name="player">玩家</param>
        /// <param name="type">类型</param>
        public static void GiveItem(Player player, ItemType type)
        {
            ItemSystem.CreateItem(type, player.Base);
        }

        /// <summary>
        /// 抛弃这个玩家的物品
        /// Drop this player's item
        /// </summary>
        public void Drop()
        {
            Base.CmdDropped();
        }

    }
}
