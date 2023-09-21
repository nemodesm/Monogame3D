using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Monogame3D;

public class ContentManager
{
    private static Microsoft.Xna.Framework.Content.ContentManager Content => Engine.Instance.Content;

    private static Dictionary<string, (object asset, HashSet<object> dependants)> _dependencies = new();
    
    /// <summary>
    /// Requests a specific MCGB asset to be loaded and marks <paramref name="object"/> as a dependency of that object
    /// </summary>
    /// <param name="assetName">The path to the asset</param>
    /// <param name="object">The object requesting the asset</param>
    /// <typeparam name="T">The type of asset that you want to load</typeparam>
    /// <returns></returns>
    public static T RequestContent<T>(string assetName, object @object)
    {
        if (!_dependencies.ContainsKey(assetName))
        {
            var asset = Content.Load<T>(assetName);
            _dependencies.Add(assetName, (asset, new HashSet<object> { @object }));
            return asset;
        }

        var t = _dependencies[assetName];
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
        if (!_dependencies.TryGetValue(assetName, out var value))
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