using Godot;
using System;

namespace Rhythia.UI;

public partial class SplashScreen : Control
{

	private AnimationPlayer? IntroSequence;

	public override void _Ready()
	{
		// RhythiaIcon = GetNode<TextureRect>("GreyBG/RhythiaIcon");
		IntroSequence = GetNode<AnimationPlayer>("GreyBG/IntroSequence");
		IntroSequence.Play("fade");
		// if (IntroSequence.IsPlaying())
		// {
		// 	GetTree().ChangeSceneToFile("res://scenes/MenuScreen.tscn");
		// 	GD.Print("Scene Changed!");
		// }
		// Called every time the node is added to the scene.
		// Initialization here.
	}

	public override void _Process(double delta)
	{
		IntroSequence = GetNode<AnimationPlayer>("GreyBG/IntroSequence");

		if (!IntroSequence.IsPlaying())
		{
			GetTree().ChangeSceneToFile("res://scenes/MenuScreen.tscn");
			GD.Print("Scene Changed!");
		}
	}

	public override void _Input(InputEvent @event)
	{
		IntroSequence = GetNode<AnimationPlayer>("GreyBG/IntroSequence");
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.Space | keyEvent.Keycode == Key.Escape)
			{
				if (IntroSequence.IsPlaying())
				{
					GetTree().ChangeSceneToFile("res://scenes/MenuScreen.tscn");
					GD.Print("Scene Changed!");
				}
			}
		}
	}
}
