using GameSystem.Enum;
using GameSystem.ItemSystem;
using JBAPI.API.Features.Interface;
using JBAPI.API.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAPI.API.Features
{
    public class Pickup : IPickup, IWapper<PickupBase>
    {
        public Pickup(PickupBase basePickup)
        {
            Base = basePickup;
        }

        public PickupBase Base { get; }
        public bool IsLocker { get => Base.IsLocker; set => Base.IsLocker = value; }
        public ItemType Type { get => Base.Type; }
        
        public void PickUp(Player player)
        {
            if (player == null)
            {
                throw new NullReferenceException("Player is null");
            }
            Base.CmdPickUp(player.Base);
        }
    }
}
