using System;
using System.Diagnostics;
using System.Linq;
using Godot;

namespace Rhythia.UI.Play;

public partial class Grid : MeshInstance3D
{
    private Vector3 InitialPosition;
    private Player? Players;

    public override void _Ready()
    {
        Players = GetParent().GetParent<Player>();

        Players.CursorPositionChanged += OnCursorPositionChanged;

        InitialPosition = Position;
    }

    private void OnCursorPositionChanged(Vector2 position)
    {
        var settings = SettingsManager.Singleton;
        var parallax = settings.Parallax + settings.HUDParallax;

        Position = InitialPosition + new Vector3(position.X, position.Y, 0) * (parallax * .1f);
    }
}