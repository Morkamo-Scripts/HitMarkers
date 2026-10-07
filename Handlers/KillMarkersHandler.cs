using LabApi.Events.Arguments.PlayerEvents;
using MEC;
using RueI.API;
using RueI.API.Elements;

namespace HitMarkers.Handlers;

public class KillMarkersHandler
{
    public void OnPlayerDeath(PlayerDeathEventArgs ev)
    {
        if (ev.Attacker == null || !Core.Instance.KillMarkersConfig.IsEnabled)
            return;

        var config = Core.Instance.KillMarkersConfig;
        var display = RueDisplay.Get(ev.Attacker); 
        
        display.Show(
            new Tag(),
            new BasicElement(
                config.VerticalPosition,
                config.MarkerMessage.Replace("%target%", ev.Player.DisplayName)
            ),
            config.MessageDuration
        );

        Timing.CallDelayed(
            config.MessageDuration + 0.2f,
            () => {
                display.Update();
            }
        );
    }
}