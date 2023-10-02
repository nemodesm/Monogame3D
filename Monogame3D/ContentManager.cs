using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace MonoGame3D;

public static class ContentManager
{
    /// <summary>
    /// Reference to the game's content manager
    /// </summary>
    private static Microsoft.Xna.Framework.Content.ContentManager Content => Engine.Instance.Content;

    /// <summary>
    /// Stores all loaded assets and their dependants, where the key is the path to the asset, and the value is a tuple
    /// (asset (as object), dependants (in a HashSet))
    /// </summary>
    private static readonly Dictionary<string, (object asset, HashSet<object> dependants)> Dependencies = new();
    
    /// <summary>
    /// Requests a specific MCGB asset to be loaded and marks <paramref name="object"/> as a dependency of that object
    /// </summary>
    /// <exception cref="ContentLoadException">Thrown if the asset cannot be loaded</exception>
    /// <param name="assetName">The path to the asset</param>
    /// <param name="object">The object requesting the asset</param>
    /// <typeparam name="T">The type of asset that you want to load</typeparam>
    /// <returns>The asset that is loaded</returns>
    public static T RequestContent<T>(string assetName, object @object)
    {
        if (!Dependencies.TryGetValue(assetName, out var value))
        {
            var asset = Content.Load<T>(assetName);
            value = (asset, new HashSet<object> { @object })!;
            Dependencies.Add(assetName, value);
            return asset;
        }

        var t = value;
        t.dependants.Add(@object);
        return (T)t.asset;
    }

    /// <summary>
    /// Marks <paramref name="object"/> as no longer dependent on the asset at <paramref name="assetName"/> and unloads
    /// it if no other dependants exist
    /// </summary>
    /// <param name="assetName">The path to the asset</param>
    /// <param name="object">The object releasing the asset</param>
    public static void UnloadAsset(string assetName, object @object)
    {
        if (!Dependencies.TryGetValue(assetName, out var value))
        {
            Debug.LogError(new ContentLoadException());
            return;
        }

        value.dependants.Remove(@object);
        if (value.dependants.Count is 0)
        {
            Content.UnloadAsset(assetName);
        }
    }

    /// <summary>
    /// Unloads all assets, regardless of whether they are still being used
    /// </summary>
    public static void Unload() => Content.Unload();
}