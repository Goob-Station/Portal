using System.Text.RegularExpressions;
using Content.Client.MainMenu.UI;
using Robust.Client;
using Robust.Client.State;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared;
using Robust.Shared.IoC;
using Robust.Shared.Configuration;
using Robust.Shared.Network;
using Robust.Shared.Utility;
using UsernameHelpers = Robust.Shared.AuthLib.UsernameHelpers;

namespace Content.Client.UserInterface.States
{
    /// <summary>
    ///     Main menu screen that is the first screen to be displayed when the game starts.
    /// </summary>
    // Instantiated dynamically through the StateManager, Dependencies will be resolved.
    public sealed class MainMenuState : State
    {
        [Dependency] private readonly IGameController _gameController = default!;
        [Dependency] private readonly IBaseClient _client = default!;
        [Dependency] private readonly IConfigurationManager _configurationManager = default!;
        [Dependency] private readonly IResourceCache _resourceCache = default!;
        [Dependency] private readonly IUserInterfaceManager _userInterfaceManager = default!;
        private MainMenuControl? _mainMenuControl;

        protected override void Startup()
        {
            _mainMenuControl = new MainMenuControl(_resourceCache, _configurationManager);
            _userInterfaceManager.StateRoot.AddChild(_mainMenuControl);

            _mainMenuControl.QuitButton.OnPressed += QuitButtonPressed;
            _mainMenuControl.ConnectButton.OnPressed += ConnectButtonPressed;
        }

        protected override void Shutdown()
        {
            _mainMenuControl.Dispose();
        }
        private void QuitButtonPressed(BaseButton.ButtonEventArgs args)
        {
            _gameController.Shutdown();
        }
        private void ConnectButtonPressed(BaseButton.ButtonEventArgs args)
        {
            _gameController.Redial("goobstation.node-offerman.simplestation.org:25510", "Connected from portal.");
        }
    }
}
