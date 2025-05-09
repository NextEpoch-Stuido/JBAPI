using APIPlayer = JBAPI.API.Features.Player;
using GameSystem.ItemSystem;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class ItemRemoveEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; private set; }
        public ItemBase Target { get; private set; }
        public ItemRemoveEventArgs(ItemBase item, APIPlayer player)
        {
            Player = player;
            Target = item;
        }
    }
}
