using System;
using System.Diagnostics;

namespace Rhythia.Maps;

public class MapInfo : IMapInfo, IEquatable<IMapInfo>
{
    public IMapMetadata Metadata { get; set; }

    public IMapSetInfo? MapSet => throw new System.NotImplementedException();

    public string Hash => throw new System.NotImplementedException();

    public MapInfo(IMapMetadata metadata)
    {
        Metadata = metadata;
    }

    private static bool compareFiles(MapInfo x, MapInfo y, Func<IMapInfo, string> getFilename)
    {
        Debug.Assert(x.MapSet != null);
        Debug.Assert(y.MapSet != null);

        // string? fileHashX = x.MapSet.GetFile(getFilename(x.Metadata))?.File.Hash;
        // string? fileHashY = y.MapSet.GetFile(getFilename(y.Metadata))?.File.Hash;

        // return fileHashX == fileHashY;

        throw new NotImplementedException();
    }

    public bool Equals(IMapInfo? other)
    {
        throw new System.NotImplementedException();
    }
}