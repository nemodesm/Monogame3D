using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace MonoGame3D._3DObjects;

public class Camera : LocalizedObject, IDrawable
{
    private readonly List<ICameraDrawable> _drawnObjects = new();

    public Matrix ViewMatrix;
    public Matrix WorldMatrix;
    public Matrix ProjectionMatrix;

    public int DrawOrder => 0;
    public bool Visible => true;

    public Color ClearColor { get; set; } = Color.CornflowerBlue;

    public event EventHandler<EventArgs>? DrawOrderChanged;
    public event EventHandler<EventArgs>? VisibleChanged;

    public Camera()
    {
        Debug.Log("Initialised Camera");
    }
    
    public Camera([NotNull] List<ICameraDrawable> drawnObjects) : this()
    {
        _drawnObjects = drawnObjects;
    }

    public void Draw(GameTime gameTime)
    {
        Engine.GraphicsDevice.Clear(ClearColor);

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
            MathHelper.ToRadians(45f), Engine.GraphicsDevice.Viewport.AspectRatio,
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