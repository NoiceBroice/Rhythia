using System;
using System.IO;

public enum SquircleFormat
{
    RHYM,
    SSPM,
    PHXM
}

public class Parsing
{
    public static SquircleFormat? GetFormat(string path)
    {
        switch (Path.GetExtension(path).ToUpper())
        {
            case nameof(SquircleFormat.PHXM):
                return SquircleFormat.PHXM;
            case nameof(SquircleFormat.SSPM):
                return SquircleFormat.SSPM;
            case nameof(SquircleFormat.RHYM):
                return SquircleFormat.RHYM;
            default:
                return null;
        }
    }
}