using System;
using System.IO;
using System.Text;

namespace Rhythia.IO.Format;

public class StreamParser
{
    private readonly Stream Stream;
    private byte[] Buffer = new byte[8];

    public long Position => Stream.Position;

    public long Seek(long offset, SeekOrigin origin) => Stream.Seek(offset, origin);

    public StreamParser(Stream stream)
    {
        Stream = stream;
    }

    public byte ReadByte()
    {
        Stream.Read(Buffer, 0, 1);

        return Buffer[0];
    }

    public bool ReadBool()
    {
        Stream.Read(Buffer, 0, 1);

        return BitConverter.ToBoolean(Buffer, 0);
    }

    public ushort ReadUInt16()
    {
        Stream.Read(Buffer, 0, 2);

        return BitConverter.ToUInt16(Buffer, 0);
    }

    public short ReadInt16()
    {
        Stream.Read(Buffer, 0, 2);

        return BitConverter.ToInt16(Buffer, 0);
    }

    public uint ReadUInt32()
    {
        Stream.Read(Buffer, 0, 4);

        return BitConverter.ToUInt32(Buffer, 0);
    }

    public int ReadInt32()
    {
        Stream.Read(Buffer, 0, 4);
        return BitConverter.ToInt32(Buffer, 0);
    }

    public ulong ReadUInt64()
    {
        Stream.Read(Buffer, 0, 8);
        return BitConverter.ToUInt64(Buffer, 0);
    }

    public long ReadInt64()
    {
        Stream.Read(Buffer, 0, 8);
        return BitConverter.ToInt64(Buffer, 0);
    }

    public float ReadSingle()
    {
        Stream.Read(Buffer, 0, 4);
        return BitConverter.ToSingle(Buffer, 0);
    }

    public double ReadDouble()
    {
        Stream.Read(Buffer, 0, 8);
        return BitConverter.ToDouble(Buffer, 0);
    }

    public string ReadString(long count)
    {
        var builder = new StringBuilder((int)count);
        int bytesRead;

        while (count > 0)
        {
            int amount = (int)Math.Min(count, Buffer.Length);
            bytesRead = Stream.Read(Buffer, 0, amount);

            if (bytesRead == 0)
                break;

            builder.Append(Encoding.UTF8.GetString(Buffer, 0, bytesRead));
            count -= bytesRead;
        }

        return builder.ToString();
    }

    public byte[] Read(long count)
    {
        byte[] buffer = new byte[count];

        Stream.Read(buffer);

        return buffer;
    }

    public string ReadLine()
    {
        var line = string.Empty;

        for (int i = Stream.Read(Buffer, 0, 1); i != 0;)
        {
            var c = Encoding.UTF8.GetString(Buffer, 0, 1);

            if (c == "\n")
                break;

            line += c;
        }

        return line;
    }
}