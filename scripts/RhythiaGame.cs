using Godot;
using LiteDB;
using Rhythia.IO;
using Rhythia.Maps;
using Rhythia.Rulesets;
using Rhythia.UI.Play;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rhythia;

[GlobalClass]
public partial class RhythiaGame : Node
{

    public static RhythiaGame Singleton => ((SceneTree)Engine.GetMainLoop()).Root.GetNode<RhythiaGame>("/root/RhythiaGame");

    public bool DebugMode => true;

    public Storage Database { get; }

    // Find a better spot for this :/
    public UserPlayingState PlayingState { get; } = UserPlayingState.NotPlaying;

    [Export]
    public RhythiaSkin? SelectedSkin { get; set; }

    public RhythiaGame()
    {
        Database = new Storage(Storage.DefaultConnection());
    }

    public override void _Ready()
    {

    }

    // Signals
    [Signal]
    public delegate void CursorPositionEventHandler(Vector2 position);

    public void CreatePlayer(Map map, Ruleset ruleset)
    {
        Player oldPlayer = GetNodeOrNull<Player>("Player");

        if (oldPlayer != null)
            oldPlayer.Dispose();

        var player = new Player()
        {
            GameplayState = new GameplayState((IMap)map, ruleset)
        };

        AddChild(player);
    }
}
