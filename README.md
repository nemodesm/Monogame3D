# Monogame 3D

Monogame 3D is a lightweight 3D extension to [Monogame](https://www.monogame.net/). It does not require any third party libraries and is entirely
self contained. All you need to do is reference it and you have the entire project ready for use.

## Getting Started

Whereas in regular Monogame, you would declare you main class for you game in the following way:

````csharp
internal class NameOfTheGame : Microsoft.Xna.Framework.Game
{
    public NameOfTheGame() { }
    
    {...}
}
````

In Monogame3D, all you need to change is to inherit from ``Monogame3D.Engine`` rather than 
``Microsoft.Xna.Framework.Game``

````csharp
internal class NameOfTheGame : MonoGame3D.Engine
{
    public NameOfTheGame() { }
    
    {...}
}
````

This will setup a Camera, Canvas, and Initialise the commonly used tools. This way, you can to jump right in to making
whatever game you cam imagine.

Of course, as this is only an extension of Monogame, I strongly recommend you take a look at
[their docs](https://docs.monogame.net/articles/getting_started) in order to get started.

### Warning

There is something to be aware of, when trying to load 3D models, you might receive an error that starts with
``Microsoft.Xna.Framework.Content.ContentLoadException: "Could not find ContentTypeReader Type.``, to fix this please
change the import properties in MCGB Editor to use Importer: ``FBX Importer`` rather than the default ``Open Asset
Import Library``. This is explained in [issue #6179](https://github.com/MonoGame/MonoGame/issues/6179) on the Monogame
repository.

## Final notes

If you have any questions, especially while the wiki if non existent, do not hesitate to contact me on Discord:

[![Discord][3]][0]

[0]: https://discord.gg/GJsQadv9Mc
[3]: https://discordapp.com/api/guilds/1172944878582370417/widget.png?style=banner3
