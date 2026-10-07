using System;
using CommandSystem;
using HitMarkers.Configs;
using LabApi.Features.Permissions;
using LabApi.Features.Wrappers;
using LabApi.Loader;
using RemoteAdmin;

namespace HitMarkers.Commands;

public class DynamicReloadCommand : ICommand
{
    public string Command { get; } = "reload";
    public string[] Aliases { get; } = Array.Empty<string>();
    public string Description { get; } = "Dynamic reload plugin configs.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (sender is PlayerCommandSender && !sender.HasPermission("hitmarkers.reload"))
        {
            response = "You don't have permission for execute this command.";
            return false;
        }

        if (!Core.Instance.TryLoadConfig<KillMarkers>("KillMarkers", out var killMarkersConfig))
        {
            response = "KillMarkers could not be loaded because has errors.";
            return false;
        }
        
        Core.Instance.KillMarkersConfig = killMarkersConfig;
        
        response = "Plugin seccessfully reloaded.";
        return true;
    }
}