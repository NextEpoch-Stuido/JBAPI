using JBAPI.Features.Hint;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using Random = System.Random;


public class SCP181Handler
{
    string DieHint = "<align=left><color=yellow><size=25>[����֪ͨ]<color=red> SCP-181���ѱ�����</color></size></align>";
    string StartHint = "<b>����\n<size=150><color=red>SCP-181</color></size>\n�и����޿�����, ��С��������˺�</b>";
    public Player SCP181;

    public readonly Random random = new Random();

    public void OnRoundStarted()
    {
        Timing.CallDelayed(2f, () =>
        {
            // ʹ��JBAPI���ѡȡ���
            SCP181 = PlayerSelectorAPI.RandomSelectPlayer(
                RoleTypeId.ClassD,
                new List<string> { "SCP181", "SCP457", "SCP550" }
            );

            if (SCP181 != null)
            {
                SCP181.RueiHint(400, StartHint, 10);

                string NewName = $"{SCP181.Id} | SCP181 | {SCP181.Nickname}";
                SCP181.DisplayNickname = NewName;
            }
        });
    }

    public void OnPlayerDied(DiedEventArgs ev)
    {
        if (ev.Target != null && ev.Target == SCP181)
        {
            DieScp181();
        }
    }

    public void OnChangingRole(ChangingRoleEventArgs ev)
    {
        if (ev.Player != null && ev.Player == SCP181)
        {
            DieScp181();
        }
    }

    public void OnPlayerHurting(HurtingEventArgs ev)
    {
        if (ev.Target == SCP181 && random.Next(100) < 40)
        {
            ev.Amount = 0;
        }
    }

    public void OnInteractingDoor(InteractingDoorEventArgs ev)
    {
        if (ev.Player == SCP181 && random.Next(100) < 30)
        {
            ev.IsAllowed = true;
        }
    }

    public void OnInteractingLocker(InteractingLockerEventArgs ev)
    {
        if (ev.Player == SCP181 && random.Next(100) < 30)
        {
            ev.IsAllowed = true;
        }
    }
    public void UnlockingGenerator(UnlockingGeneratorEventArgs ev)
    {
        if (ev.Player == SCP181 && random.Next(100) < 30)
        {
            ev.IsAllowed = true;
        }
    }
    public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
    {
        if (ev.Player == SCP181 && random.Next(100) < 30)
        {
            ev.IsAllowed = true;
        }
    }

    private void DieScp181()
    {
        foreach (Player p in Player.List)
        {
            p.ARueiHint(400, DieHint, 5);
        }

        string NewName = $"{SCP181?.Id} | {SCP181?.Nickname}";
        SCP181.DisplayNickname = NewName;
        SCP181 = null;
    }
}