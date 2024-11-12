using Content.Client.UserInterface.States;
using JetBrains.Annotations;
using Robust.Client;
using Robust.Client.State;
using Robust.Shared.IoC;

namespace Content.Client.UserInterface;

/// <summary>
///     Handles changing the UI state depending on whether we're connecting/connected to a server, etc.
/// </summary>
[UsedImplicitly]
public sealed class HudManager
{
    [Dependency] private readonly IGameController _gameController = default!;
    [Dependency] private readonly IBaseClient _client = default!;
    [Dependency] private readonly IStateManager _stateManager = default!;

    public void Initialize()
    {
        _client.RunLevelChanged += ((_, args) =>
        {
            _stateManager.RequestStateChange<MainMenuState>();
        });
    }
}