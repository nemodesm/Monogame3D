using Microsoft.Xna.Framework;

namespace Monogame3D._3DObjects;

public class LocalizedObject : IGameComponent
{
    protected Engine Engine => Engine.Instance;

    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Size;

    public Vector3 RotationEuler
    {
        get => QuaternionExtension.ToEulerAngles(Rotation);
        set => Rotation = QuaternionExtension.Euler(value);
    }

    protected LocalizedObject() { }

    public virtual void Initialize() { }
}