using Microsoft.Xna.Framework;

namespace MonoGame3D.InputSystem;

public struct GamePadSet
{
    private GamePadState[] _gamePadStates = new GamePadState[4];

    public GamePadState this[PlayerIndex index] => _gamePadStates[(int)index];
    
    public GamePadSet() { }

    public static GamePadSet GetState(InputState inputState)
    {
        var gamePadStates = new []
        {
            GamePadState.GetState(inputState, PlayerIndex.One),
            GamePadState.GetState(inputState, PlayerIndex.Two),
            GamePadState.GetState(inputState, PlayerIndex.Three),
            GamePadState.GetState(inputState, PlayerIndex.Four)
        };
        return new GamePadSet() { _gamePadStates = gamePadStates};
    }
}