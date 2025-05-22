using System.Collections.Generic;
using Rhythia.Maps;

public class MapMetadata : IMapMetadata
{
    public string AudioExtension => throw new System.NotImplementedException();

    public string Artist => throw new System.NotImplementedException();

    public string Title => throw new System.NotImplementedException();

    public IEnumerable<string> Mappers => throw new System.NotImplementedException();

    public string DifficultyName => throw new System.NotImplementedException();

    public int NoteCount => throw new System.NotImplementedException();

    public bool Equals(IMapMetadata? other)
    {
        throw new System.NotImplementedException();
    }
}