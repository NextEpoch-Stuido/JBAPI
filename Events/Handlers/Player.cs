using JBAPI.Events.EventArgs.Player;
using System;

namespace JBAPI.Events.Handlers
{
    public static class Player
    {
        public static event Action<ItemAppeadingEventArgs>? ItemAppeading;
        public static event Action<ItemRemoveEventArgs>? ItemRemove;
        public static event Action<ItemMaxReachedEventArgs>? ItemMaxReached;
        public static event Action<VerifiedEventArgs>? Verifed;
        public static event Action<JoinedEventArgs>? Joined;
        public static event Action<HurtEventArgs>? Hurt;
        public static event Action<LeftEventArgs>? Left;
        public static event Action<DiedEventArgs>? Died;
        public static event Action<ChangedRoleEventArgs>? ChangedRole;
        public static event Action<ChangingRoleEventArgs>? ChangingRole;
        public static void OnItemAppeading(ItemAppeadingEventArgs ev) => ItemAppeading?.Invoke(ev);
        public static void OnItemRemove(ItemRemoveEventArgs ev) => ItemRemove?.Invoke(ev);
        public static void OnItemMaxReached(ItemMaxReachedEventArgs ev) => ItemMaxReached?.Invoke(ev);
        public static void OnDied(DiedEventArgs ev) => Died?.Invoke(ev);
        public static void OnHurt(HurtEventArgs ev) => Hurt?.Invoke(ev);
        public static void OnLeft(LeftEventArgs ev) => Left?.Invoke(ev);
        public static void OnVerifed(VerifiedEventArgs ev) => Verifed?.Invoke(ev);
        public static void OnJoined(JoinedEventArgs ev) => Joined?.Invoke(ev);
        public static void OnChangedRole(ChangedRoleEventArgs ev) => ChangedRole?.Invoke(ev);
        public static void OnChangingRole(ChangingRoleEventArgs ev) => ChangingRole?.Invoke(ev);
    }
}
