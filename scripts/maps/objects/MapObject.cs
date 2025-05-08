using Godot;

namespace Rhythia.Maps.Objects;

public abstract class MapObject
{
    int Millisecond { get; }

    int HitWindow { get; }
}