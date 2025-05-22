using System;
using Godot;

namespace Rhythia.Maps.Objects;

public class HitObject : IComparable<HitObject>
{
    public virtual int Millisecond { get; set; }

    public virtual int HitWindow { get; set; }

    public virtual int CompareTo(HitObject? obj)
    {
        if (obj is null)
            return -1;

        return Millisecond.CompareTo(obj.Millisecond);
        
    }

}