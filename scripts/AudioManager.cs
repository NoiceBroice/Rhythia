using Godot;

namespace Rhythia;

public partial class AudioManager : Node
{
    public static AudioManager Singleton => (AudioManager)((SceneTree)Engine.GetMainLoop()).Root.GetNode("/root/AudioManager");
    
}