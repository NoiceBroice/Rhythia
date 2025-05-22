using Godot;
using Rhythia;
using Rhythia.UI.Play;

public partial class Camera : Camera3D
{
    private Player Player;
    private Vector3 InitialPosition;

    public override void _Ready()
    {
        Player = GetParent().GetParent<Player>();
        InitialPosition = Position;

        Player.CursorPositionChanged += OnCursorPositionChanged;
    }

    private void OnCursorPositionChanged(Vector2 position)
    {
        var settings = SettingsManager.Singleton;
        var parallax = settings.Parallax + settings.CameraParallax;

        Position = InitialPosition + new Vector3(position.X, position.Y, 0) * (parallax * .1f);
    }
}