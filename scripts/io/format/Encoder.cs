using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rhythia.IO.Format;


public abstract class Encoder<TOutput> : Encoder
    where TOutput : new()
{
    /// <summary>
    /// Encodes an object
    /// </summary>
    /// <param name="path">Path file / directory to parse</param>
    /// <returns></returns>
    public abstract TOutput Encode(string path);
}

/// <summary>
/// Encoding map files
/// </summary>
public abstract class Encoder
{
    private static readonly Dictionary<Type, Dictionary<string, Func<string, Encoder>>> Encoders = new();
    
    static Encoder()
    {
        
    }

    /// <summary>
    /// Retrieves a <see cref=Encoder"/> to parse an object
    /// </summary>
    /// <param name="key">The key assigned to the encoder</param>
    public static Encoder<T> GetEncoder<T>(string key)
        where T : new()
    {
        ArgumentNullException.ThrowIfNull(key);

        if (!Encoders.TryGetValue(typeof(T), out var typedEncoders))
            throw new IOException("Unknown encoder type");

        var Encoder = typedEncoders.Where(d => d.Key == key).Select(d => d.Value).FirstOrDefault();

        if (Encoder != null)
            return (Encoder<T>) Encoder.Invoke(key);
        
        throw new NotImplementedException("Encoder is not implemented yet");
    }

    /// <summary>
    /// Adds a encoder that can be used to parse objects
    /// </summary>
    public static void AddEncoder<T>(string key, Func<string, Encoder> constructor)
    {
        if (!Encoders.TryGetValue(typeof(T), out var typedEncoders))
            Encoders.Add(typeof(T), typedEncoders = new Dictionary<string, Func<string, Encoder>>());

        typedEncoders[key] = constructor;
    }
}