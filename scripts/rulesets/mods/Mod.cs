using System;

public abstract class Mod : IMod, IEquatable<Mod>
{
    public virtual string Description => "Description of mod";

    public virtual Type[] IncompatibleMods => Array.Empty<Type>();

    public virtual string Name => "Mod";

    public virtual string Acronym => "MD";

    public bool Equals(Mod? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return GetType() == other.GetType();
    }
}