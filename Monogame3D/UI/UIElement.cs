using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public class UIElement : HierarchyElement<UIElement>, ICanvasDrawable
{
    #region Fields

    #region Utilities

    /// <summary>
    /// The name of this UI element
    /// </summary>
    /// <remarks>
    /// No checks are made to ensure that this name is unique in the UI tree
    /// </remarks>
    public override string Name { get; set; } = "UI Element";
    
    protected internal Canvas Canvas => Parent is null ? (Canvas)this : Parent.Canvas;

    #endregion

    #region Positioning
    
    private AnchorPosition _anchorPosition;
    
    /// <summary>
    /// Where this UI element is anchored to relative to the parent element
    /// </summary>
    public virtual AnchorPosition AnchorPosition
    {
        get => _anchorPosition;
        set => _anchorPosition = value;
    }

    private Rectangle _position = new(0, 0, 100, 100);

    /// <summary>
    /// The bounding rectangle of this UI element as it would appear on a 1920x1080 screen
    /// </summary>
    public virtual Rectangle Position
    {
        get => _position;
        set => _position = value;
    }

    /// <summary>
    /// The bounding rectangle of this UI element as it would appear on the current screen
    /// </summary>
    public virtual Rectangle ScaledPosition
    {
        get
        {
            if (AnchorPosition == AnchorPosition.Absolute)
            {
                return Position;
            }
            
            var scaledParent = Parent!.ScaledPosition;
            var screenScale = ScreenScale;
            var (x, y) = ((int)(Position.X * screenScale.X), (int)(Position.Y * screenScale.Y));
            var (width, height) = ((int)(Position.Width * screenScale.X), (int)(Position.Height * screenScale.Y));
            
            return AnchorPosition switch
            {
                AnchorPosition.TopLeft => new Rectangle(x + scaledParent.X, y + scaledParent.Y, width, height),
                AnchorPosition.TopCenter => new Rectangle(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.TopRight => new Rectangle(
                    scaledParent.Width - width - x + scaledParent.X,
                    y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.CenterLeft => new Rectangle(
                    x + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.Center => new Rectangle(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.CenterRight => new Rectangle(
                    scaledParent.Width - width - x + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomLeft => new Rectangle(
                    x + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomCenter => new Rectangle(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomRight => new Rectangle(
                    scaledParent.Width - width - x + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.Absolute => throw new ArgumentOutOfRangeException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public Vector2 ScreenScale => new(Engine.Graphics.PreferredBackBufferWidth / 1920f,
        Engine.Graphics.PreferredBackBufferHeight / 1080f);

    #endregion

    #region Object Fields
    
    /// <summary>
    /// The list of components that are attached to this UI element
    /// </summary>
    protected readonly HashSet<UIComponent> Components = new();

    #endregion

    #endregion

    #region Constructors
    
    public UIElement(params UIComponent[] components) : this("New UI Element", components) { }
    public UIElement(string name, params UIComponent[] components)
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        this.Name = name;
            
        foreach (var component in components)
        {
            component.Element = this;
            Components.Add(component);
        }
    }
    public UIElement(Rectangle position, AnchorPosition anchorPosition, params UIComponent[] components) : this("New UI Element", components)
    {
        this._position = position;
        this._anchorPosition = anchorPosition;
    }
    public UIElement(string name, Rectangle position, AnchorPosition anchorPosition, params UIComponent[] components) : this(name, components)
    {
        this._position = position;
        this._anchorPosition = anchorPosition;
    }
    
    [Obsolete(message: "Support for copying properties from one UI element to another was removed in alpha 3, any newer feature will not be copied")]
    public UIElement(UIElement uiElement)
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        this.Name = uiElement.Name;
        // ReSharper disable once VirtualMemberCallInConstructor
        this.AnchorPosition = uiElement.AnchorPosition;
        this.Enabled = uiElement.Enabled;
        this.UpdateOrder = uiElement.UpdateOrder;
        this.Parent = uiElement.Parent;
        this.Children = uiElement.Children;
        this.Components = uiElement.Components;
    }

    #endregion

    #region Methods

    #region Components
    
    /// <summary>
    /// Adds a component to this UI Element
    /// </summary>
    /// <param name="component">The component to add to this element</param>
    public virtual void AddComponent(UIComponent component)
    {
        if (component.Element != this && component.Element is not null)
        {
            Debug.LogError(new InvalidOperationException());
        }
        component.Element = this;
        Components.Add(component);
            
        component.Initialise();
    }

    /// <summary>
    /// Gets the first component of type <typeparamref name="T"/> that is attached to this UI element
    /// </summary>
    /// <typeparam name="T">The type of the component to get - must be of type <see cref="UIComponent"/></typeparam>
    /// <returns>The first component of type <typeparamref name="T"/> attached to this element</returns>
    public T? GetComponent<T>() where T : UIComponent
    {
        foreach (var component in Components)
        {
            if (component is T t)
            {
                return t;
            }
        }

        return null;
    }
    
    /// <summary>
    /// Gets all the components of type <typeparamref name="T"/> that are attached to this UI element
    /// </summary>
    /// <typeparam name="T">The type of the component to get - must be of type <see cref="UIComponent"/></typeparam>
    /// <returns>The components of type <typeparamref name="T"/> attached to this element</returns>
    public T[] GetComponents<T>() where T : UIComponent => Components.OfType<T>().ToArray();

    #endregion
    
    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!this.Enabled)
        {
            return;
        }
        
        foreach (var component in Components)
        {
            component.Draw(gameTime, spriteBatch);
        }

        foreach (var uiElement in Children)
        {
            if (uiElement.Enabled)
            {
                uiElement.Draw(gameTime, spriteBatch);
            }
        }
    }

    public void Initialize()
    {
        foreach (var element in Children)
        {
            element.Initialize();
        }

        foreach (var component in Components)
        {
            component.Initialise();
        }
    }

    #endregion
}