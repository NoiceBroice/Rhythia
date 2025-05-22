using System;
using System.IO.Compression;

namespace Rhythia.Maps;

public interface IMapSetInfo : IHasFileId
{
    public IMapSetMetadata Metadata { get; }

    public float Difficulty { get; }
}