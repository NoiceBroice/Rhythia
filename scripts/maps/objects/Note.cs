using Godot;

namespace Rhythia.Maps.Objects;

public class Note : HitObject
{
    public Vector2 Position { get; set; }

    public float Size { get; set; } = 1;

    public float X
    {
        get => Position.X;
        set => Position = new Vector2(value, Position.Y);
    }

    public float Y
    {
        get => Position.Y;
        set => Position = new Vector2(Position.X, value);
    }

    public Note()
    {
        
    }

    public Note(int millisecond, float x, float y)
    {
        Millisecond = millisecond;
        Position = new Vector2(x, y);
    }

    public Note(int millisecond, Vector2 position)
    {
        Millisecond = millisecond;
        Position = position;
    }
}