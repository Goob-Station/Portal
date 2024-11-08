using System;
using System.Text.RegularExpressions;
using Content.Client.UserInterface.Hud;
using Robust.Client;
using Robust.Client.State;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared;
using Robust.Shared.Configuration;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Utility;
using UsernameHelpers = Robust.Shared.AuthLib.UsernameHelpers;

namespace Content.Client.UserInterface.States;

public sealed class MainMenuState : State
{
    [Dependency] private readonly IBaseClient _client = default!;
    [Dependency] private readonly IClientNetManager _netManager = default!;
    [Dependency] private readonly IGameController _gameController = default!;
    [Dependency] private readonly IConfigurationManager _cfgManager = default!;
    [Dependency] private readonly IUserInterfaceManager _userInterface = default!;
        
    // ReSharper disable once InconsistentNaming
    private static readonly Regex IPv6Regex = new(@"\[(.*:.*:.*)](?::(\d+))?");
        
    private MainMenuHud? _mainMenu;
        
    protected override void Startup()
    {
        _mainMenu = new MainMenuHud
        { };

        _mainMenu.OnConnectButtonPressed += OnConnectPressed;
        _netManager.ConnectFailed += OnConnectFailed;

        LayoutContainer.SetAnchorAndMarginPreset(_mainMenu, LayoutContainer.LayoutPreset.Wide);
            
        _userInterface.StateRoot.AddChild(_mainMenu);
    }
        
    protected override void Shutdown()
    {
        _netManager.ConnectFailed -= OnConnectFailed;
        _mainMenu?.Dispose();
    }
        
    private void OnConnectFailed(object? sender, NetConnectFailArgs e)
    {
        _userInterface.Popup($"Disconnected: {e.Reason}", "Disconnected");
    }

    private void OnConnectPressed(BaseButton.ButtonEventArgs obj)
    {
        _gameController.Redial("goobstation.node-offerman.simplestation.org:25510", "Connected from portal.");
    }
}