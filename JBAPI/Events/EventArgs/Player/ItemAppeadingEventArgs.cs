using APIPlayer = JBAPI.API.Features.Player;
using GameSystem.ItemSystem;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class ItemAppeadingEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public ItemBase Item { get; }
        public bool IsAllowed { get; }
        public ItemAppeadingEventArgs(ItemBase item, APIPlayer player)
        {
            Player = player;
            Item = item;
            IsAllowed = true;
        }
    }
}
