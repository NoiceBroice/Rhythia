using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Godot;
using Rhythia.Maps;
using Rhythia.Maps.Objects;

namespace Rhythia.IO.Format;

public class SSPMDecoder : Decoder<Map>
{

    public static void Register()
    {
        AddDecoder<Map>(".sspm", (_) => new SSPMDecoder());
    }

    public override Map Decode(Stream stream)
    {
        Map map;
        var parser = new StreamParser(stream);

        try
        {
            if (parser.ReadString(4) != "SS+m")
                throw new("Invalid file signature");

            var version = parser.ReadUInt16();

            switch (version)
            {
                case 1:
                    map = ParseSSPMV1(parser);
                    break;
                case 2:
                    map = ParseSSPMV2(parser);
                    break;
                default:
                    throw new("Unsupported SSPM version");
            }
        }
        catch (Exception)
        {
            throw;
        }

        return map;
    }

    private Map ParseSSPMV1(StreamParser parser)
    {
        var map = new Map();

        byte[]? coverBuffer = null;
        byte[]? audioBuffer = null;

        string? artist = null;
        string? song = null;

        try
        {
            parser.Seek(2, SeekOrigin.Current); // Reserved
            string id = parser.ReadLine();


            string[] mapName = parser.ReadLine().Split(" - ", 2);
            string[] mappers = parser.ReadLine().Split(['&', ',']);

            uint mapLength = parser.ReadUInt32();
            uint noteCount = parser.ReadUInt32();

            ushort difficulty = parser.ReadUInt16();

            foreach (var name in mapName)
                name.StripEdges();

            if (mapName.Length == 1)
            {
                song = mapName[0];
            }
            else
            {
                artist = mapName[0];
                song = mapName[1];
            }

            bool hasCover = parser.ReadUInt16() == 2;

            if (hasCover)
            {
                long coverLength = (long)parser.ReadUInt64();
                coverBuffer = parser.Read(coverLength);
            }

            bool hasAudio = parser.ReadUInt16() == 2;

            if (hasAudio)
            {
                long audioLength = (long)parser.ReadUInt64();
                audioBuffer = parser.Read(audioLength);
            }

            HitObject[] hitObjects = new HitObject[noteCount];

            for (int i = 0; i < noteCount; i++)
            {
                int millisecond = (int)parser.ReadUInt32();
                bool isQuantum = parser.ReadBool();

                var position = new Vector2();

                if (isQuantum)
                {
                    position.X = parser.ReadSingle();
                    position.Y = parser.ReadSingle();
                }
                else
                {
                    position.X = parser.ReadUInt16();
                    position.Y = parser.ReadUInt16();
                }

                hitObjects[i] = new Note(millisecond, position);
            }

            Array.Sort(hitObjects);

            map.Audio = audioBuffer;
            map.Cover = coverBuffer;
            map.HitObjects = [.. hitObjects];
            
        }
        catch
        {
            throw;
        }

        return map;
    }

    private Map ParseSSPMV2(StreamParser parser)
    {
        var map = new Map();
        byte[]? audioBuffer = null;
        byte[]? coverBuffer = null;

        string? artist = null;
        string? song = null;

        try
        {
            parser.Seek(4, SeekOrigin.Current); // Reserved
            parser.Seek(20, SeekOrigin.Current); // Hash

            var mapLength = parser.ReadUInt32();
            var noteCount = parser.ReadUInt32();

            parser.Seek(4, SeekOrigin.Current); // marker count

            var difficulty = parser.ReadByte();

            var starRating = parser.ReadUInt16();

            var hasAudio = parser.ReadByte() == 1;
            var hasCover = parser.ReadByte() == 1;

            var hasMod = parser.ReadByte() == 1;

            parser.ReadUInt64(); // Custom data offset
            var customDataLength = parser.ReadUInt64();

            var audioDataOffset = parser.ReadUInt64();
            var audioDataLength = parser.ReadUInt64();

            var coverDataOffset = parser.ReadUInt64();
            var coverDataLength = parser.ReadUInt64();

            var markerDefinitionOffset = parser.ReadUInt64();
            var markerDefinitionLength = parser.ReadUInt64();

            var markerDataOffset = parser.ReadUInt64();
            var markerDataLength = parser.ReadUInt64();

            var mapIdLength = parser.ReadUInt16();
            parser.Seek(mapIdLength, SeekOrigin.Current); // MapManager will assign a new id for converted map

            var mapNameLength = parser.ReadUInt16();
            var mapName = parser.ReadString(mapIdLength).Split(" - ");

            foreach (var name in mapName)
                name.StripEdges();

            if (mapName.Length == 1)
            {
                song = mapName[0];
            }
            else
            {
                artist = mapName[0];
                song = mapName[1];
            }

            var songNameLength = parser.ReadUInt16();
            parser.Seek(songNameLength, SeekOrigin.Current); // Song name (not used)

            var mappersCount = parser.ReadUInt16();
            var mappers = new List<string>();

            while (mappersCount > 0)
            {
                mappersCount--;

                var mapperNameLength = parser.ReadUInt16();
                mappers.Add(parser.ReadString(mapperNameLength));
            }

            // To lazy to add custom data parsing for custom difficulty name will add that later


            if (hasAudio)
            {
                parser.Seek((long)audioDataOffset, SeekOrigin.Begin);
                audioBuffer = parser.Read((long)audioDataLength);
            }

            if (hasCover)
            {
                parser.Seek((long)coverDataOffset, SeekOrigin.Begin);
                coverBuffer = parser.Read((long)coverDataLength);
            }

            // Handle definitions for custom data types
            // parser.Seek((long)markerDefinitionOffset, SeekOrigin.Begin);
            // var definition = parser.ReadByte();

            parser.Seek((long)markerDataOffset, SeekOrigin.Begin);

            HitObject[] hitObjects = new HitObject[noteCount]; // Only caring about notes

            for (uint i = 0; i < noteCount; i++)
            {
                var millisecond = (int)parser.ReadUInt32();

                parser.ReadByte();

                bool isQuantum = parser.ReadBool();
                var position = new Vector2();

                if (isQuantum)
                {
                    position.X = parser.ReadSingle();
                    position.Y = parser.ReadSingle();
                }
                else
                {
                    position.X = parser.ReadByte();
                    position.Y = parser.ReadByte();
                }

                hitObjects[i] = new Note(millisecond, position);
            }

            Array.Sort(hitObjects);

            map.Audio = audioBuffer;
            map.Cover = coverBuffer;
            map.HitObjects = hitObjects.ToList();
        }
        catch
        {
            throw;
        }

        return map;
    }
}