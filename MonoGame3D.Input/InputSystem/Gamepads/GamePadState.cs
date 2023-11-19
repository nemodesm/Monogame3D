using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

public struct GamePadState
{
    public bool Connected;
        
    public GamePadButtons PressedButtons;
    public GamePadButtons PressedButtonsLastFrame;
        
    public GamePadTriggers Triggers;
    public GamePadTriggers TriggersLastFrame;
        
    public GamePadDPad DPad;
    public GamePadDPad DPadLastFrame;
        
    public GamePadThumbSticks Sticks;
    public GamePadThumbSticks SticksLastFrame;
    
    public static GamePadState GetState(InputState inputState, PlayerIndex playerIndex)
    {
        var st = GamePad.GetState(playerIndex);
        
        var gamePadState = new GamePadState();
            
        gamePadState.Connected = st.IsConnected;
        
        gamePadState.PressedButtonsLastFrame = inputState.GamePadStates[playerIndex].PressedButtons;
        gamePadState.PressedButtons = st.Buttons;
            
        gamePadState.TriggersLastFrame = inputState.GamePadStates[playerIndex].Triggers;
        gamePadState.Triggers = st.Triggers;
            
        gamePadState.DPadLastFrame = inputState.GamePadStates[playerIndex].DPad;
        gamePadState.DPad = st.DPad;
            
        gamePadState.SticksLastFrame = inputState.GamePadStates[playerIndex].Sticks;
        gamePadState.Sticks = st.ThumbSticks;
        
        return gamePadState;
    }
}