using Godot;
using System;

namespace Rhythia;

[GlobalClass]
public partial class RhythiaGame : Node
{

    [Export]
    public RhythiaSkin SelectedSkin { get; set; }

    public override void _Ready()
    {
        
    }

}
