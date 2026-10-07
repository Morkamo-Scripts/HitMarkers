using System;
using HitMarkers.Configs;
using HitMarkers.Handlers;
using LabApi.Features;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using api = LabApi.Events.Handlers;

namespace HitMarkers
{
    public class Core : Plugin
    {
        public static Core Instance { get; private set; }
        
        public override string Name { get; } = "HitMarkers";
        public override string Description { get; } = "HitMarkers utilities plugin";
        public override string Author { get; } = "Morkamo";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);
        
        public KillMarkers KillMarkersConfig { get; internal set; }
        
        public KillMarkersHandler KillMarkersHandler { get; private set; }
        
        public override void Enable()
        {
            Instance = this;
            
            KillMarkersConfig = this.LoadConfig<KillMarkers>("KillMarkers");
            
            KillMarkersHandler = new KillMarkersHandler();
            
            SubscribeEvents();
        }

        public override void Disable()
        {
            UnsubscribeEvents();
            
            KillMarkersConfig = null;
            
            KillMarkersHandler = null;
            
            Instance = null;
        }

        private void SubscribeEvents()
        {
            api.PlayerEvents.Death += KillMarkersHandler.OnPlayerDeath;
        }
        
        private void UnsubscribeEvents()
        {
            api.PlayerEvents.Death -= KillMarkersHandler.OnPlayerDeath;
        }
    }
}