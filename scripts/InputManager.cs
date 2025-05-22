using System;
using System.Reflection.Metadata;
using Godot;
using Rhythia;

/// <summary>
/// Abstraction of Godot's InputManager and binds to relative settings
/// </summary>
public partial class InputManager : Node
{
    private SettingsManager SettingsManager;

    public event EventHandler<InputEventMouse>? InputEventMouse;

    public event EventHandler<InputEventKey>? InputEventKey;

    public event EventHandler<InputEventAction>? InputEventAction;

    public InputManager(SettingsManager _settingsManager)
    {
        SettingsManager = _settingsManager;
    }

    // public override void _UnhandledKeyInput(InputEvent @event)
    // {
    //     InputEventKey?.Invoke(this, (InputEventKey)@event);
    // }

    // public override void _UnhandledInput(InputEvent @event)
    // {
    //     switch (@event)
    //     {
    //         case InputEventMouse e:
    //             InputEventMouse?.Invoke(this, e);
    //             break;
            
    //         case InputEventKey e:
    //             InputEventKey?.Invoke(this, e);
    //             break;

    //         case InputEventAction e:
    //             InputEventAction?.Invoke(this, e);
    //             break;

    //         default:
    //             return;
    //     }
    // }

}