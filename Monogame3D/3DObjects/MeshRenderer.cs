using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame3D.Exceptions;

namespace MonoGame3D._3DObjects;

public class MeshRenderer : LocalizedObject, ICameraDrawable
{
    private readonly Model? _model;

    public MeshRenderer(string modelName)
    {
        try
        {
            _model = ContentManager.RequestContent<Model>(modelName, this);
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
        if (_model is null)
            return;
        
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