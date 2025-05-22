using System;
using Godot;

namespace Rhythia.Maps.Objects;

public class HitObject : IComparable
{
    public virtual int Millisecond { get; set; }

    public virtual int HitWindow { get; set; }

    public virtual int CompareTo(object? obj)
    {
        if (obj is not HitObject hitObj)
            throw new ArgumentException($"{nameof(obj)} is not an instance of {nameof(HitObject)}");

        if (Millisecond == hitObj.Millisecond )
            return 0;

        return Millisecond > hitObj.Millisecond ? 1 : -1;
        
    }

}