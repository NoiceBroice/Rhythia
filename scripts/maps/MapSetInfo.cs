using LiteDB;

namespace Rhythia.Maps;

public class MapSetInfo : IMapSetInfo
{
    [BsonId]
    public required ObjectId FileId { get; set; }

    public required MapSetInfo Metadata { get; set; }

    public float Difficulty { get; set; } = -1;

    public int Length { get; set; } = -1;

    IMapSetMetadata IMapSetInfo.Metadata => Metadata;
}