using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Rhythia.Maps;

namespace Rhythia.IO;

public class MapStorage 
{
    public const string DEFUALT_SONGS_PATH = "maps";

    private string MapPath;

    public MapStorage(string path)
    {
        MapPath = path == string.Empty ? $"user://{DEFUALT_SONGS_PATH}" : path;
        Debug.Assert(MapPath != null); // Should never be null but ¯\_(ツ)_/¯
    }

    public Task LoadMapSets(Action<IMapSetInfo> onMapSetLoaded)
    {
        throw new NotImplementedException();
    }

    public IMapSetInfo? GetMapSet(string name)
    {
        throw new NotImplementedException();
    }

    public Map GetMap(IMapSetInfo mapSetInfo, string difficultyName)
    {
        throw new NotImplementedException();
    }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}