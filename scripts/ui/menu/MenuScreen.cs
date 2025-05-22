using Godot;

namespace Rhythia.UI;

public partial class MenuScreen : Control
{
    private Control? Background;

    public override void _Ready()
    {
        Background = GetNode<Control>("Background");
    }

    public void Initialize()
    {
        
    }
}