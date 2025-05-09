using APIPlayer = JBAPI.API.Features.Player;
using GameSystem.Enum;

namespace JBAPI.Events.EventArgs.Player
{
    public class ChangingRoleEventArgs
    {
        public APIPlayer Player { get; }
        public RoleType OldRole { get; }
        public RoleType NewRole { get; }
        public bool IsAllowed { get; set; }
        public ChangingRoleEventArgs(RoleType oldRole, RoleType newRole, APIPlayer player)
        {
            Player = player;
            OldRole = oldRole;
            NewRole = newRole;
            IsAllowed = true;
        }
    }
}
