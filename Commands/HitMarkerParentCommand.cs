using System;
using CommandSystem;

namespace HitMarkers.Commands;

[CommandHandler(typeof(ClientCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
public sealed class HitMarkerParentCommand : ParentCommand
{
    public override string Command { get; } = "hitmarkers";
    public override string[] Aliases { get; } = Array.Empty<string>();
    public override string Description { get; } = "HitMarkers utility commands.";

    public HitMarkerParentCommand()
    {
        LoadGeneratedCommands();
    }

    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new DynamicReloadCommand());
    }
    
    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "Available subcommands: reload";
        return false;
    }
}