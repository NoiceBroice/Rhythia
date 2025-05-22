using System.Collections.Generic;
using Godot;
using Rhythia.Maps;
using Rhythia.Maps.Objects;

public interface IMapInfoCached : IMapInfo, IHasFileId
{
    public Image Cover { get; }

    public byte[] Video {get;}

    public IList<HitObject> HitObjects { get; }
}