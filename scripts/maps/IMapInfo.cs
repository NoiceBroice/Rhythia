using System;

namespace Rhythia.Maps;

/// <summary>
/// A singular map information
/// </summary>
public interface IMapInfo : IEquatable<IMapInfo>
{
    /// <summary>
    /// The metadata within the map.
    /// </summary>
    IMapMetadata Metadata { get; }

    /// <summary>
    /// The MapSet this map is part of
    /// </summary>
    IMapSetInfo? MapSet { get; }

    /// <summary>
    /// Hash of map's objects used to match against replays
    /// </summary>
    string Hash { get; }
}