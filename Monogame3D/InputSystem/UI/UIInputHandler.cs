using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.UI;

namespace MonoGame3D.InputSystem.UI;

/// <summary>
/// Handles navigation within the UI
/// </summary>
public class UIInputHandler : GameComponent
{
    private IUISelectable? _currentlySelected;

    /// <summary>
    /// The currently selected UI component
    /// </summary>
    public IUISelectable? CurrentSelection
    {
        get => _currentlySelected;
        set
        {
            _currentlySelected?.Deselect();
            _currentlySelected = value;
            _currentlySelected?.Select();
        }
    }
    
    public UIInputHandler(Game game) : base(game) { }
    
    public override void Update(GameTime gameTime)
    {
        if (!Input.UIInput || CurrentSelection is null) return;
        
        var nav = CurrentSelection.NavigationData;
        if (Input.GetKeyDown(Keys.Up) && nav.Up is not null) CurrentSelection = nav.Up;
        if (Input.GetKeyDown(Keys.Down) && nav.Down is not null) CurrentSelection = nav.Down;
        if (Input.GetKeyDown(Keys.Left) && nav.Left is not null) CurrentSelection = nav.Left;
        if (Input.GetKeyDown(Keys.Right) && nav.Right is not null) CurrentSelection = nav.Right;

        if (Input.GetKeyDown(Keys.Enter) && CurrentSelection is ISubmitHandler submitHandler) submitHandler.Submit();
    }
}