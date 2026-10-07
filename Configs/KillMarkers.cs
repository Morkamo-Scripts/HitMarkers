using System;
using System.ComponentModel;

namespace HitMarkers.Configs;

[Serializable]
public class KillMarkers
{
    public bool IsEnabled { get; set; } = true;

    [Description("Hint vertical position.")]
    public short VerticalPosition { get; set; } = 200;
    
    [Description("Show duration.")]
    public float MessageDuration { get; set; } = 1f;
    
    [Description("%target% - killed player.")]
    public string MarkerMessage { get; set; } = "You killed %target%";
}