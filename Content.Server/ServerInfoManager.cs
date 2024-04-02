// MIT License
//
// Copyright (c) 2017-2024 Space Wizards Federation
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Text.Json.Nodes;
using Content.Shared;
using Robust.Server.ServerStatus;
using Robust.Shared.Configuration;
using Robust.Shared.IoC;
using Robust.Shared.Localization;

namespace Content.Server;

/// <summary>
/// Adds additional data like info links to the server info endpoint
/// </summary>
public sealed class ServerInfoManager
{
    private static readonly (CVarDef<string> cVar, string icon, string name)[] Vars =
    {
        // @formatter:off
        (ContentCVars.InfoLinksDiscord, "discord", "info-link-discord"),
        (ContentCVars.InfoLinksForum,   "forum",   "info-link-forum"),
        (ContentCVars.InfoLinksGithub,  "github",  "info-link-github"),
        (ContentCVars.InfoLinksWebsite, "web",     "info-link-website"),
        (ContentCVars.InfoLinksWiki,    "wiki",    "info-link-wiki")
        // @formatter:on
    };

    [Dependency] private readonly IStatusHost _statusHost = default!;
    [Dependency] private readonly IConfigurationManager _cfg = default!;
    [Dependency] private readonly ILocalizationManager _loc = default!;

    public void Initialize()
    {
        _statusHost.OnInfoRequest += OnInfoRequest;
    }

    private void OnInfoRequest(JsonNode json)
    {
        foreach (var (cVar, icon, name) in Vars)
        {
            var url = _cfg.GetCVar(cVar);
            if (string.IsNullOrEmpty(url))
                continue;

            StatusHostHelpers.AddLink(json, _loc.GetString(name), url, icon);
        }
    }
}