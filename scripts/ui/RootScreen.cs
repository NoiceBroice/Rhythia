using System;
using System.Collections.Generic;
using Godot;
using Rhythia;

enum Screen
{
	Menu,
	Maps,
	Game
}

public partial class RootScreen : Control
{
	Dictionary<Screen, Control> Screens = new();

	private RhythiaGame Game { get; set; } = new();

	public override void _Ready()
	{
		Game = GetTree().Root.GetNode<RhythiaGame>("RhythiaGame");
		
	}
}
