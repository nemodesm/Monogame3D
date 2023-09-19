using System.Diagnostics.CodeAnalysis;
using Engine.Exceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine._3DObjects
{
    internal class MeshRenderer : LocalizedObject, ICameraDrawable
    {
        private readonly Model _model;

        public MeshRenderer([NotNull] Game game, [NotNull] Model model) : base(game)
        {
            this._model = model;
        }

        public MeshRenderer([NotNull] Game game, string modelName) : base(game)
        {
            this._model = game.Content.Load<Model>(modelName);
            
            if (this._model is null)
                Debug.LogError(new InvalidModelException());
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