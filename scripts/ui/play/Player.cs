using System;
using Godot;

namespace Rhythia.UI.Play;

// Player can send events where the UI can attach itself to those events
// Ex: Cursor position update in logic invokes event and UI responds to change

public partial class Player : Node
{
    private GameplayState? State;

    public event Action GameplayStarted;

    private IBindable<bool> gameActive = new Bindable<bool>();

    [Signal]
    public delegate void CursorEventHandler(Vector2 position);

    public Player()
    {

    }
}