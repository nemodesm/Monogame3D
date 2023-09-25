using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D.Exceptions;

namespace Monogame3D._3DObjects;

public class MeshRenderer : LocalizedObject, ICameraDrawable
{
    private readonly Model _model;

    public MeshRenderer([NotNull] Model model)
    {
        _model = model;
    }

    public MeshRenderer(string modelName)
    {
        try
        {
            _model = Engine.Content.Load<Model>(modelName);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
            
        Engine.Camera.RegisterCameraDrawable(this);
            
        if (_model is null)
            Debug.LogError(new InvalidModelException());
    }

    ~MeshRenderer()
    {
        // game.Content.UnloadAsset("MonoCube");
            
        Engine.Camera.DeregisterCameraDrawable(this);
    }

    void ICameraDrawable.Draw(GameTime gameTime, Camera camera)
    {
        foreach (var mesh in _model.Meshes)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var t in mesh.Effects)
            {
                var effect = (BasicEffect)t;

                effect.AmbientLightColor = new Vector3(1f, 0, 0);
                effect.View = camera.ViewMatrix;
                effect.World = camera.WorldMatrix;
                effect.Projection = camera.ProjectionMatrix;
            }

            mesh.Draw();
        }
    }
}