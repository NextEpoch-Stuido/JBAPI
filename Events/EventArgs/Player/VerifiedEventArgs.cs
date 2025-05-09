using APIPlayer = JBAPI.API.Features.Player;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class VerifiedEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public VerifiedEventArgs(APIPlayer player)
        {
            Player = player;
        }
    }
}
