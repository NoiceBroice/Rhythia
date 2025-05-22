using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Godot;
using Rhythia.IO.Format;
using Rhythia.Maps;
using Rhythia.Maps.Objects;
using Rhythia.Scoring;

namespace Rhythia.UI.Play;

// Player can send events where the UI can attach itself to those events
// Ex: Cursor position update in logic invokes event and UI responds to change

public partial class Player : Node
{
    public required GameplayState GameplayState { get; set; }

    public event Action GameplayStarted;

    private bool gameActive = false;

    public Vector2 CursorPosition { get; private set; } = new();

    private JudgementProcessor? JudgementProcessor;

    private ScoreProcessor? ScoreProcessor;

    private HealthProcessor? HealthProcessor;

    [Signal]
    public delegate void CursorPositionChangedEventHandler(Vector2 position);

    public override void _Ready()
    {
        // JudgementProcessor = GameplayState.Ruleset.CreateJudgementProcessor();
        // ScoreProcessor = GameplayState.Ruleset.CreateScoreProcessor();
        // HealthProcessor = GameplayState.Ruleset.CreateHealthProcessor();

        GetWindow().FilesDropped += OnFilesDropped;
    }

    public override void _Process(double delta)
    {
        if (RhythiaGame.Singleton.DebugMode) return;

        Debug.Assert(GameplayState != null);


        if (GameplayState.PlayingState != UserPlayingState.Playing)
            return;



    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion e)
            _HandleMouse(e);

    }

    private void _HandleMouse(InputEventMouseMotion mouse)
    {


        var xPos = Mathf.Clamp(CursorPosition.X + mouse.Relative.X, -1, 1);

        var yPos = Mathf.Clamp(CursorPosition.Y + mouse.Relative.Y, -1, 1);

        CursorPosition = new Vector2(xPos, yPos);

        EmitSignal(nameof(CursorPositionChanged), CursorPosition);
    }

    /// <summary>
    /// Processes grid updates
    /// </summary>
    private void _ProcessGrid()
    {

    }

    /// <summary>
    /// Processes camera updates
    /// </summary>
    private void ProcessCamera()
    {

    }


    private void ProcessHitObjects()
    {

    }

    private void ProcessHUD()
    {

    }

    private void OnFilesDropped(string[] files)
    {
        foreach (var file in files)
        {
            Stream fileStream = File.OpenRead(file);

            var map = Decoder.GetDecoder<Map>(Path.GetExtension(file)).Decode(fileStream);
            int count = 10;
            foreach (var hitObject in map.HitObjects)
            {
                count--;
                if (hitObject is Note note)
                {
                    GD.Print(note.Millisecond);
                    GD.Print(note.Position);
                }

                if (count < 0)
                    return;
            }
        }
    }
}