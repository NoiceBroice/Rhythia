using System;
using System.Collections.Generic;
using Rhythia.Maps.Objects;

namespace Rhythia.Maps;

public class CachedMap
{
    Lazy<List<MapObject>> MapObjects => new(() => _GetMapObjects(), false);

    private List<MapObject> _GetMapObjects()
    {
        throw new NotImplementedException();
    }
}
