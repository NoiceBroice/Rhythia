using Godot;
using Rhythia.UI.Play;
using System;
using System.Diagnostics;
using System.Linq;

namespace Rhythia.UI.Play;

public partial class PlayScreen : Node
{
    private Player? Player;

    private SettingsManager _SettingsManager;

    // Grid nodes
    [Export] public MeshInstance3D? Grid;

    private MeshInstance3D? Cursor;
    private Node3D? Note;

    [Export] public Node3D? HUD;

    [Export] public Camera3D? Camera;


    public override void _Ready()
    {
        //_SettingsManager =  RhythiaGame.Container.GetInstance<SettingsManager>();
        //Player = (Player)GetTree().GetNodesInGroup(RhythiaGroups.Player.ToString()).FirstOrDefault()!;
        //Debug.Assert(Grid != null);
        //Debug.Assert(HUD != null);
        //Debug.Assert(Camera != null);

        // Cursor = Grid.GetNode<MeshInstance3D>("Cursor");
        // Note = Grid.GetNode<Node3D>("Note");
    }

    public override void _Process(double delta)
    {
        
    }

    // public override void _UnhandledInput(InputEvent @event)
    // {
    //     switch(@event)
    //     {
    //         case InputEventMouseMotion e:
    //             HandleMouseMotion(e);
    //             break;
    //     }

    // }
    
    // private void HandleMouseMotion(InputEventMouseMotion @event)
    // {
    //     var rel = @event.Relative;
    // }

}
