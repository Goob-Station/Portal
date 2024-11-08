using Content.Client.UserInterface;
using Content.Shared;
using Robust.Shared.IoC;
using Content.Client.Parallax.Managers;

namespace Content.Client;

internal static class ClientContentIoC
{
    public static void Register()
    {
        SharedContentIoC.Register();
            
        IoCManager.Register<IParallaxManager, ParallaxManager>();
        IoCManager.Register<HudManager, HudManager>();
        IoCManager.Register<StyleSheetManager, StyleSheetManager>();
    }
}