using Robust.Client.AutoGenerated;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared;
using Robust.Shared.Configuration;
using System;

namespace Content.Client.MainMenu.UI;

[GenerateTypedNameReferences]
public sealed partial class MainMenuControl  : Control
{
    public MainMenuControl(IResourceCache resCache, IConfigurationManager configMan)
    {
        RobustXamlLoader.Load(this);

        LayoutContainer.SetAnchorPreset(this, LayoutContainer.LayoutPreset.Wide);
    
        LayoutContainer.SetAnchorPreset(VBox, LayoutContainer.LayoutPreset.TopRight);
        LayoutContainer.SetMarginRight(VBox, -25);
        LayoutContainer.SetMarginTop(VBox, 30);
        LayoutContainer.SetGrowHorizontal(VBox, LayoutContainer.GrowDirection.Begin);

        var logoTexture = resCache.GetResource<TextureResource>("/Textures/Logo/logo.png");
        Logo.Texture = logoTexture;
    }
}
