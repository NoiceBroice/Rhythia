using Godot;

namespace Rhythia;

public partial class SettingsManager : Node
{
    public static SettingsManager Singleton => (SettingsManager)((SceneTree)Engine.GetMainLoop()).Root.GetNode("/root/SettingsManager");

    // Parallax Settings
    public float Parallax { get; } = 5;
    public float CameraParallax { get; } = 1;
    public float HUDParallax { get; } = 0;

    // Cursor Settings
    public float GUICursorSize { get; } = 1;
    public float GameCursorSize { get; } = 1;
    public float Sensitivity { get; } = .5f;

}