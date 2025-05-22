using Godot;
using Rhythia.UI.Play;

public partial class Cursor : MeshInstance3D
{
    private Player Player;

    public override void _Ready()
    {
        Player = GetParent().GetParent().GetParent<Player>();

        Player.CursorPositionChanged += OnCursorPositionChanged;
    }

    public void _Process()
    {

    }

    private void OnCursorPositionChanged(Vector2 position)
    {

    }

}