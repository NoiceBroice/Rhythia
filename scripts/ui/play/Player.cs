using System;
using System.Diagnostics;
using Godot;

namespace Rhythia.UI.Play;

// Player can send events where the UI can attach itself to those events
// Ex: Cursor position update in logic invokes event and UI responds to change

public partial class Player : Node
{
    public required GameplayState GameplayState { get; set; }

    public event Action GameplayStarted;

    private bool gameActive = false;

    public Vector2 CursorPosition { get; private set; } = new();

    [Signal]
    public delegate void CursorPositionChangedEventHandler(Vector2 position);

    public override void _Ready()
    {

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

        GD.Print(CursorPosition);

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
    private void _ProcessCamera()
    {

    }


    private void _ProcessHitObjects()
    {

    }

    private void _ProcessHUD()
    {

    }
}