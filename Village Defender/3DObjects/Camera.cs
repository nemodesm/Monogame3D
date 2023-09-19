using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace VillageDefender._3DObjects
{
    internal class Camera : LocalizedObject, IDrawable
    {
        private List<ICameraDrawable> drawnObjects = new();

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

        public Camera([NotNull] Game game) : base(game)
        {
        }
        public Camera([NotNull] Game game, [NotNull] List<ICameraDrawable> drawnObjects) : base(game)
        {
            this.drawnObjects = drawnObjects;
        }

        public void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(_clearColor);

            foreach (var drawable in drawnObjects)
            {
                drawable.Draw(gameTime, this);
            }
        }

        public override void Initialize()
        {
            //Setup Camera
            Rotation = Quaternion.Identity;
            Position = new Vector3(0f, 0f, -5);

            // ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
            //     MathHelper.ToRadians(45f), game._graphics.
            //         GraphicsDevice.Viewport.AspectRatio,
            //     1f, 1000f);
            // ViewMatrix = Matrix.CreateLookAt(_camPosition, _camTarget,
            //     new Vector3(0f, 1f, 0f));// Y up
            // WorldMatrix = Matrix.CreateWorld(_camTarget, Vector3.
            //     Forward, Vector3.Up);

            base.Initialize();
        }
    }
}
