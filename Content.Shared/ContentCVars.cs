using Robust.Shared;
using Robust.Shared.Configuration;

namespace Content.Shared;

[CVarDefs]
public sealed class ContentCVars: CVars
{
    // ----- BALL CVARS -----
    /// <summary>
    ///     Factor by which the ball speed is multiplied every time it collides with a paddle.
    /// </summary>
    public static readonly CVarDef<float> BallSpeedup =
        CVarDef.Create("ball.speedup", 1.15f, CVar.REPLICATED | CVar.SERVER);

    /// <summary>
    ///     The ball will be sped up based on the average score.
    /// </summary>
    public static readonly CVarDef<float> BallSpeedupScore =
        CVarDef.Create("ball.speedup_score", 0.05f, CVar.REPLICATED | CVar.SERVER);

    /// <summary>
    ///     Maximum speed the ball will move at.
    /// </summary>
    public static readonly CVarDef<float> BallMaximumSpeed =
        CVarDef.Create("ball.maximum_speed", 200f, CVar.REPLICATED | CVar.SERVER);
        
    // ----- PONG CVARS -----
        
    /// <summary>
    ///     Number of points a player has to score to win.
    /// </summary>
    public static readonly CVarDef<int> PongWinThreshold =
        CVarDef.Create("pong.win_threshold", 10, CVar.SERVERONLY);
        
    /// <summary>
    ///     Time to wait after the game has ended before restarting.
    /// </summary>
    public static readonly CVarDef<float> PongRestartTimer =
        CVarDef.Create("pong.restart_timer", 10f, CVar.SERVERONLY);
        
    // ----- PADDLE CVARS -----
        
    /// <summary>
    ///     Paddle movement speed.
    /// </summary>
    public static readonly CVarDef<float> PaddleSpeed =
        CVarDef.Create("pong.paddle_speed", 7f, CVar.REPLICATED | CVar.SERVER);

    /// -- Start MIT License --

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

    
    /// <summary>
    /// Link to Discord server to show in the launcher.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksDiscord =
        CVarDef.Create("infolinks.discord", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to website to show in the launcher.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksForum =
        CVarDef.Create("infolinks.forum", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to GitHub page to show in the launcher.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksGithub =
        CVarDef.Create("infolinks.github", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to website to show in the launcher.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksWebsite =
        CVarDef.Create("infolinks.website", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to wiki to show in the launcher.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksWiki =
        CVarDef.Create("infolinks.wiki", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to Patreon. Not shown in the launcher currently.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksPatreon =
        CVarDef.Create("infolinks.patreon", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to the bug report form.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksBugReport =
        CVarDef.Create("infolinks.bug_report", "", CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    /// Link to site handling ban appeals. Shown in ban disconnect messages.
    /// </summary>
    public static readonly CVarDef<string> InfoLinksAppeal =
        CVarDef.Create("infolinks.appeal", "", CVar.SERVER | CVar.REPLICATED);
}

/// -- End MIT License --