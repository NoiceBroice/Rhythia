using System;
using System.Collections.Generic;
using System.IO;
using Rhythia.IO;

namespace Rhythia.Maps;

public class MapImporter
{
    private MapStorage Storage;

    public static HashSet<string> ValidExtensions => new()
    {
        "rhym",
        "sspm",
        "phxm"
    };

    public MapImporter(MapStorage storage)
    {
        Storage = storage;
    }

    public Map? ImportMap(string path)
    {
        // Stream stream;

        // if (Parsing.GetFormat(path) == null)
        //     return null;

        // try
        // {
        //     stream = File.OpenRead(path);
        // }
        // catch (DirectoryNotFoundException exception)
        // {
        //     Logger.Log(exception.Message, true);
        //     return null;
        // }
        
        // var fileBuffer = new byte[stream.Length];
        // stream.Read(fileBuffer);

        // Map beatmap = Decoder.GetDecoder<Map>(Path.GetExtension(path)).Decode(fileBuffer);
        
        // return Map;

        throw new NotImplementedException();
    }
}