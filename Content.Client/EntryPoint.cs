using Content.Client.UserInterface;
using JetBrains.Annotations;
using Robust.Client.Graphics;
using Robust.Shared.ContentPack;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using Content.Client.Parallax.Managers;

// DEVNOTE: Games that want to be on the hub can change their namespace prefix in the "manifest.yml" file.
namespace Content.Client;

[UsedImplicitly]
public sealed class EntryPoint : GameClient
{
    [Dependency] private readonly IParallaxManager _parallaxManager = default!;
    public override void PreInit()
    { 
        IoCManager.Resolve<IClyde>().SetWindowTitle("Robust Pong");
    }

    public override void Init()
    {
        var factory = IoCManager.Resolve<IComponentFactory>();
        var prototypes = IoCManager.Resolve<IPrototypeManager>();

        factory.DoAutoRegistrations();

        foreach (var ignoreName in IgnoredComponents.List)
        {
            factory.RegisterIgnore(ignoreName);
        }

        foreach (var ignoreName in IgnoredPrototypes.List)
        {
            prototypes.RegisterIgnore(ignoreName);
        }

        ClientContentIoC.Register();

        IoCManager.BuildGraph();
            
        factory.GenerateNetIds();
            
        IoCManager.Resolve<StyleSheetManager>().Initialize();
        IoCManager.Resolve<HudManager>().Initialize();
    }

    public override void PostInit()
    {
        base.PostInit();

        // Pong doesn't need fancy lighting or FOV.
        IoCManager.Resolve<ILightManager>().Enabled = false;
        _parallaxManager.LoadDefaultParallax();
        var overlayManager = IoCManager.Resolve<IOverlayManager>();
            
    }
}