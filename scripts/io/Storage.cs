using Rhythia.IO;

public class Storage
{
    private MapStorage MapStorage;

    public Storage(string mapPath)
    {
        MapStorage = new MapStorage(mapPath);
    }
}