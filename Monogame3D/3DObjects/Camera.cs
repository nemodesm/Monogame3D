using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Monogame3D._3DObjects
{
    public class Camera : LocalizedObject, IDrawable
    {
        private readonly List<ICameraDrawable> _drawnObjects = new();

        public Matrix ViewMatrix;
        public Matrix WorldMatrix;
        public Matrix ProjectionMatrix;
        private Color _clearColor = Color.CornflowerBlue;

        public int DrawOrder => 0;
        public bool Visible => true;

        public Color ClearColor
        {
            get => _clearColor;
            set => _clearColor = value;
        }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public Camera([NotNull] Engine game) : base(game)
        {
            Debug.Log("Initialised Camera");
        }
        public Camera([NotNull] Engine game, [NotNull] List<ICameraDrawable> drawnObjects) : this(game)
        {
            this._drawnObjects = drawnObjects;
        }

        public void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(_clearColor);

            foreach (var drawable in _drawnObjects)
            {
                drawable.Draw(gameTime, this);
            }
        }

        public override void Initialize()
        {
            //Setup Camera
            RotationEuler = Vector3.Zero;
            Position = new Vector3(0f, 1f, -10);

            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45f), game.GraphicsDevice.Viewport.AspectRatio,
                1f, 1000f);
            // TODO: _camTarget need to be replaced with PositionedObject.Forward (which is not implemented)
            // ViewMatrix = Matrix.CreateLookAt(Position, _camTarget,
            //     new Vector3(0f, 1f, 0f));// Y up
            // WorldMatrix = Matrix.CreateWorld(_camTarget, Vector3.
            //     Forward, Vector3.Up);

            base.Initialize();
        }

        public void RegisterCameraDrawable(ICameraDrawable drawable)
        {
            _drawnObjects.Add(drawable);
        }
        public void DeregisterCameraDrawable(ICameraDrawable drawable)
        {
            _drawnObjects.Remove(drawable);
        }
    }
}
