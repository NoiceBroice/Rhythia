using System.Collections.Generic;
using Rhythia.Maps.Objects;

namespace Rhythia.Maps;

public class Map : IMap
{
    public byte[]? Audio { get; set; }
    public byte[]? Cover { get; set; }

    public List<string> ColorSet { get; set; }

    public List<HitObject> HitObjects { get; set; }

    public MapMetadata Metadata { get; set; }

    IList<string> IMap.ColorSet => ColorSet;

    IMapMetadata IMap.Metadata => Metadata;

    IReadOnlyList<HitObject> IMap.HitObjects => HitObjects;
}