using System.Collections.Generic;
using Rhythia.Maps;

namespace Rhythia.Maps;

public class MapSetMetadata : IMapSetMetadata
{
    public int Version => throw new System.NotImplementedException();

    public string AudioExtension => throw new System.NotImplementedException();

    public string Artist => throw new System.NotImplementedException();

    public string RomanizedArtist => throw new System.NotImplementedException();

    public string Title => throw new System.NotImplementedException();

    public string RomanizedTitle => throw new System.NotImplementedException();

    public IList<IMapInfo> Difficulties => throw new System.NotImplementedException();
}