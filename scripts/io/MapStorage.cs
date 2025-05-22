using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using LiteDB;
using Rhythia.Maps;

namespace Rhythia.IO;

public class MapStorage 
{
    public const string MAPS_COLLECTION = "maps";

    private readonly ILiteStorage<string> _FileStorage;
    private readonly ILiteCollection<MapSetMetadata> _MapCollection;

    public MapStorage(ILiteDatabase liteDatabase)
    {
        _MapCollection = liteDatabase.GetCollection<MapSetMetadata>(MAPS_COLLECTION);
    }

    public void LoadMapSets()
    {
        _MapCollection.Query().Where("*").Select("*");
    }

    /// <summary>
    /// Update the mapSet
    /// </summary>
    /// <param name="mapSet"></param>
    /// <returns></returns>
    public bool UpdateMapSet(MapSetMetadata mapSet)
    {
        // TODO: Update cached files based on map update

        return _MapCollection.Update(mapSet);
    }

    public bool GetMapCover(MapInfo mapInfo, Stream cover)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.FindById($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/cover.png");

        if (info != null)
            info.CopyTo(cover);
        
        return info != null;
    }

    public bool GetMapAudio(MapInfo mapInfo, Stream audio)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.FindById($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/audio.{mapInfo.Metadata.AudioExtension}");
        
        if (info != null)
            info.CopyTo(audio);
        
        return info != null;
    }

    public bool GetMapVideo(MapInfo mapInfo, Stream video)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.FindById($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/video.mp4");
        
        if (info != null)
            info.CopyTo(video);
        
        return info != null;
    }

    public bool SetMapCover(MapInfo mapInfo, Stream cover)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.Upload($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/cover.png", "cover.png", cover);
        
        return info != null;
    }
    
    public bool SetMapAudio(MapInfo mapInfo, Stream audio)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.Upload($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/cover.png", "cover.png", audio);
        
        return info != null;
    }

    public bool SetMapVideo(MapInfo mapInfo, Stream video)
    {
        Debug.Assert(mapInfo.MapSet != null);

        var info = _FileStorage.Upload($"{mapInfo.MapSet.FileId}/{mapInfo.Metadata.DifficultyName}/cover.png", "cover.png", video);
        
        return info != null;
    }
}