using Godot;

namespace Rhythia.Maps.Objects;

public class Note : MapObject
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

    public Note(int millisecond, float x, float y)
    {

    }
}