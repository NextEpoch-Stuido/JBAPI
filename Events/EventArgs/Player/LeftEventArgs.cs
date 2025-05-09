using APIPlayer = JBAPI.API.Features.Player;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class LeftEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public LeftEventArgs(APIPlayer player)
        {
            Player = player;
        }
    }
}
