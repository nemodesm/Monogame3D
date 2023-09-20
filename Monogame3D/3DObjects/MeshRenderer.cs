using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame3D.Exceptions;

namespace Monogame3D._3DObjects
{
    public class MeshRenderer : LocalizedObject, ICameraDrawable
    {
        private readonly Model _model;

        public MeshRenderer([NotNull] Engine game, [NotNull] Model model) : base(game)
        {
            this._model = model;
        }

        public MeshRenderer([NotNull] Engine game, string modelName) : base(game)
        {
            try
            {
                this._model = game.Content.Load<Model>(modelName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
            
            game.Camera.RegisterCameraDrawable(this);
            
            if (this._model is null)
                Debug.LogError(new InvalidModelException());
        }

        ~MeshRenderer()
        {
            // game.Content.UnloadAsset("MonoCube");
            
            game.Camera.DeregisterCameraDrawable(this);
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
}