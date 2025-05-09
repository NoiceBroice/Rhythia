using System;
using System.Collections.Generic;
using Godot;

enum Screen
{
    Menu,
    Maps,
    Game
}

public partial class RootScreen : Control
{
    Dictionary<Screen, Control> Screens;

    public override void _Ready()
    {
        
    }
}