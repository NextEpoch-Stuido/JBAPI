using APIPlayer = JBAPI.API.Features.Player;
using JBAPI.Events.Interfaces;

namespace JBAPI.Events.EventArgs.Player
{
    public class HurtEventArgs : IPlayerEvent
    {
        public APIPlayer Player { get; }
        public HurtEventArgs(APIPlayer player) 
        {
            Player = player;
        }
    }
}
