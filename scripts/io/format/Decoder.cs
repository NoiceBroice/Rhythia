using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rhythia.IO.Format;


public abstract class Decoder<TOutput> : Decoder
    where TOutput : new()
{
    /// <summary>
    /// Decodes an object
    /// </summary>
    /// <param name="path">Path of file / directory to parse</param>
    /// <returns></returns>
    public abstract TOutput Decode(string path);
}

/// <summary>
/// Decoding map files
/// </summary>
public abstract class Decoder
{
    private static readonly Dictionary<Type, Dictionary<string, Func<string, Decoder>>> decoders = new();
    
    static Decoder()
    {
        
    }

    /// <summary>
    /// Retrieves a <see cref=Decoder"/> to parse an object
    /// </summary>
    /// <param name="key">The key assigned to the decoder</param>
    public static Decoder<T> GetDecoder<T>(string key)
        where T : new()
    {
        ArgumentNullException.ThrowIfNull(key);

        if (!decoders.TryGetValue(typeof(T), out var typedDecoders))
            throw new IOException("Unknown decoder type");

        var decoder = typedDecoders.Where(d => d.Key == key).Select(d => d.Value).FirstOrDefault();

        if (decoder != null)
            return (Decoder<T>) decoder.Invoke(key);
        
        throw new NotImplementedException("Decoder is not implemented yet");
    }

    /// <summary>
    /// Adds a decoder that can be used to parse objects
    /// </summary>
    public static void AddDecoder<T>(string key, Func<string, Decoder> constructor)
    {
        if (!decoders.TryGetValue(typeof(T), out var typedDecoders))
            decoders.Add(typeof(T), typedDecoders = new Dictionary<string, Func<string, Decoder>>());

        typedDecoders[key] = constructor;
    }
}