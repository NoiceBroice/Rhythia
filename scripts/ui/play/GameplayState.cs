using Godot;
using Rhythia.Maps;
using Rhythia.Rulesets;
using Rhythia.Scoring;
using System;
using System.Collections.Generic;

namespace Rhythia.UI.Play;

public partial class GameplayState
{
    /// <summary>
    /// The final post-converted post-mod-application beatmap
    /// </summary>
    public readonly IMap Map;

    /// <summary>
    /// The ruleset used for gameplay
    /// </summary>
    public readonly Ruleset Ruleset;
    
    /// <summary>
    /// Handles score information
    /// </summary>
    public readonly ScoreProcessor ScoreProcessor;

    /// <summary>
    /// Handles health information
    /// </summary>
    public readonly HealthProcessor HealthProcessor;

    /// <summary>
    /// The mods applied to the gameplay
    /// </summary>
    public readonly IReadOnlyList<Mod> Mods;

    /// <summary>
    /// The gameplay score
    /// </summary>
    public readonly Score Score;

    /// <summary>
    /// Whether gameplay completed without user failing
    /// </summary>
    public bool HasPassed { get; set; }

    /// <summary>
    /// Whether the user failed during gameplay. This is only set when the gameplay session has completed due to the fail.
    /// </summary>
    public bool HasFailed { get; set; }

    /// <summary>
    /// Whether the user quit gameplay without having either passed or failed.
    /// </summary>
    public bool HasQuit { get; set; }
    
    /// <summary>
    /// signals
    /// </summary>
    public bool HasCompleted => HasPassed || HasFailed || HasQuit;

    public UserPlayingState PlayingState { get; } = UserPlayingState.NotPlaying;


    public GameplayState(
        IMap map,
        Ruleset ruleset,
        IReadOnlyList<Mod>? mods = null
    )
    {
        Map = map;
        Ruleset = ruleset;
        Mods = mods ?? Array.Empty<Mod>();
        ScoreProcessor = ruleset.CreateScoreProcessor();
        HealthProcessor = ruleset.CreateHealthProcessor();
        Score = new();
    }
}
