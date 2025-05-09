using Godot;

namespace Rhythia.UI;

public partial class MenuScreen : Control
{
    private Control Background;
    private VideoStreamPlayer _videoPlayback;
    public override void _Ready()
    {
        Background = GetNode<Control>("Background");
        _videoPlayback = Background.GetNode<VideoStreamPlayer>("Video");

        _videoPlayback.Stream.File = "test";
        _videoPlayback.Play();
        // This works hopefully if not would need to add a bridge to gdscript
        _videoPlayback.StreamPosition = 12;
    }

    public void Initialize()
    {
        
    }
}