using APIPlayer = JBAPI.API.Features.Player;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class JoinedEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public JoinedEventArgs(APIPlayer player)
        {
            Player = player;
        }
    }
}
