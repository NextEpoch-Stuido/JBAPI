using APIPlayer = JBAPI.API.Features.Player;
using GameSystem.Enum;

namespace JBAPI.Events.EventArgs.Player
{
    public class ChangedRoleEventArgs
    {
        public APIPlayer Player { get;  }
        public RoleType OldRole { get; }
        public RoleType NewRole { get; }
        public ChangedRoleEventArgs(RoleType oldRole, RoleType newRole, APIPlayer player)
        {
            Player = player;
            OldRole = oldRole;
            NewRole = newRole;
        }
    }
}
