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
        IoCManager.Resolve<IClyde>().SetWindowTitle("Goobstation Portal");
    }

    public override void Init()
    {
        var factory = IoCManager.Resolve<IComponentFactory>();
        var prototypes = IoCManager.Resolve<IPrototypeManager>();

        ClientContentIoC.Register();

        IoCManager.BuildGraph();
        IoCManager.InjectDependencies(this);

        factory.DoAutoRegistrations();
        factory.GenerateNetIds();

        foreach (var ignoreName in IgnoredComponents.List)
        {
            factory.RegisterIgnore(ignoreName);
        }

        foreach (var ignoreName in IgnoredPrototypes.List)
        {
            prototypes.RegisterIgnore(ignoreName);
        }

        IoCManager.Resolve<StyleSheetManager>().Initialize();
        IoCManager.Resolve<HudManager>().Initialize();
    }

    public override void PostInit()
    {
        base.PostInit();

        IoCManager.Resolve<ILightManager>().Enabled = false;
        _parallaxManager.LoadDefaultParallax();
        var overlayManager = IoCManager.Resolve<IOverlayManager>();
            
    }
}