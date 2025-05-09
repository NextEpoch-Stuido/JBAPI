using APIPlayer = JBAPI.API.Features.Player;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class DiedEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public DiedEventArgs(APIPlayer player)
        {
            Player = player;
        }
    }
}
