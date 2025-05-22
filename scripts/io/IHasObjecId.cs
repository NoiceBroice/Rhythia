using LiteDB;

public interface IHasFileId
{
    public ObjectId FileId { get; }
}