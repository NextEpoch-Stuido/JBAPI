using JBAPI.Events.Handlers;

namespace JBAPI.Events
{
    internal static class EventLoader
    {
        public static void RegEvents()
        {
            GameSystem.EventManager.Handler.Role.OnRoleChanging += OnRoleChanging;
            GameSystem.EventManager.Handler.Role.OnRoleChanged += OnRoleChanged;
            GameSystem.EventManager.Handler.Network.OnVerifed += OnVerifed;
            GameSystem.EventManager.Handler.Network.OnLeft += OnLeft;
            GameSystem.EventManager.Handler.Network.OnJoining += OnJoined;
            GameSystem.EventManager.Handler.Player.OnPlayerDied += OnPlayerDied;
            GameSystem.EventManager.Handler.Player.OnPlayerDamaged += OnPlayerDamaged;
            GameSystem.EventManager.Handler.Item.OnItemMaxReached += OnItemMaxReached;
            GameSystem.EventManager.Handler.Item.OnItemAdded += OnItemAppeading;
            GameSystem.EventManager.Handler.Item.OnItemRemoved += OnItemRemove;
        }
        public static void UnregEvents()
        {
            GameSystem.EventManager.Handler.Role.OnRoleChanging -= OnRoleChanging;
            GameSystem.EventManager.Handler.Role.OnRoleChanged -= OnRoleChanged;
            GameSystem.EventManager.Handler.Network.OnVerifed -= OnVerifed;
            GameSystem.EventManager.Handler.Network.OnLeft -= OnLeft;
            GameSystem.EventManager.Handler.Network.OnJoining -= OnJoined;
            GameSystem.EventManager.Handler.Player.OnPlayerDied -= OnPlayerDied;
            GameSystem.EventManager.Handler.Player.OnPlayerDamaged -= OnPlayerDamaged;
            GameSystem.EventManager.Handler.Item.OnItemMaxReached -= OnItemMaxReached;
            GameSystem.EventManager.Handler.Item.OnItemAdded -= OnItemAppeading;
            GameSystem.EventManager.Handler.Item.OnItemRemoved -= OnItemRemove;
        }
        private static void OnRoleChanging(GameSystem.EventManager.Args.RoleChangingArgs ev) => Player.OnChangingRole(new EventArgs.Player.ChangingRoleEventArgs(ev.OldRole, ev.NewRole, new API.Features.Player(ev.PlayerHub)));
        private static void OnRoleChanged(GameSystem.EventManager.Args.RoleChangedArgs ev) => Player.OnChangedRole(new EventArgs.Player.ChangedRoleEventArgs(ev.OldRole, ev.NewRole, new API.Features.Player(ev.PlayerHub)));
        private static void OnVerifed(GameSystem.EventManager.Args.VerifiedEventArgs ev) => Player.OnVerifed(new EventArgs.Player.VerifiedEventArgs(new API.Features.Player(ev.PlayerHub)));
        private static void OnLeft (GameSystem.EventManager.Args.LeftEventArgs ev) => Player.OnLeft(new EventArgs.Player.LeftEventArgs(new API.Features.Player(ev.PlayerHub)));
        private static void OnJoined(GameSystem.EventManager.Args.JoiningEventArgs ev) => Player.OnJoined(new EventArgs.Player.JoinedEventArgs(new API.Features.Player(ev.PlayerHub)));
        private static void OnPlayerDied(GameSystem.EventManager.Args.PlayerDiedEventArgs ev) => Player.OnDied(new EventArgs.Player.DiedEventArgs(new API.Features.Player(ev.PlayerHub)));
        private static void OnPlayerDamaged(GameSystem.EventManager.Args.PlayerDamagedEventArgs ev) => Player.OnHurt(new EventArgs.Player.HurtEventArgs(new API.Features.Player(ev.PlayerHub)));
        private static void OnItemMaxReached(GameSystem.EventManager.Args.ItemMaxReachedEventArgs ev) => Player.OnItemMaxReached(new EventArgs.Player.ItemMaxReachedEventArgs(ev.Target,new API.Features.Player(ev.PlayerHub)));
        private static void OnItemAppeading(GameSystem.EventManager.Args.ItemAddedEventArgs ev) => Player.OnItemAppeading(new EventArgs.Player.ItemAppeadingEventArgs(ev.Item, new API.Features.Player(ev.PlayerHub)));
        private static void OnItemRemove(GameSystem.EventManager.Args.ItemRemovedEventArgs ev) => Player.OnItemRemove(new EventArgs.Player.ItemRemoveEventArgs(ev.Item, new API.Features.Player(ev.PlayerHub)));

    }
}
