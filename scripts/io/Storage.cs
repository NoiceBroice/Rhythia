using System;
using LiteDB;

namespace Rhythia.IO;

/// <summary>
/// Handles local folder and database
/// </summary>
public class Storage : LiteDatabase
{
    public Storage(string connectionString, BsonMapper? mapper = null) : base(connectionString, mapper)
    {

    }

    public static string DefaultConnection()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        + $"/{(string)Godot.ProjectSettings.GetSetting("application/config/name")}"
        + "/data.db";
    }
}