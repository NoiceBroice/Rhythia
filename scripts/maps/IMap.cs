using System.Collections.Generic;
using Rhythia.Maps.Objects;

namespace Rhythia.Maps;

public interface IMap
{
    public byte[]? Audio { get; }

    public byte[]? Cover { get; }

    public IList<string> ColorSet { get; }

    public IReadOnlyList<HitObject> HitObjects { get; }

    public IMapMetadata Metadata { get; }
}