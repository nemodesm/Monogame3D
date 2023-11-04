using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        set
        {
            _anchorPosition = value;
            
            OnPositionChanged();
        }
    }

    private Rectangle _position = new(0, 0, 100, 100);

    /// <summary>
    /// The bounding rectangle of this UI element as it would appear on a 1920x1080 screen
    /// </summary>
    public virtual Rectangle Position
    {
        get => _position;
        set
        {
            _position = value;
            
            OnPositionChanged();
        }
    }

    /// <summary>
    /// The bounding rectangle of this UI element as it would appear on the current screen
    /// </summary>
    public virtual Rectangle ScaledPosition
    {
        get;
        private set;
    }

    protected internal static Vector2 ScreenScale => new(Engine.Graphics.PreferredBackBufferWidth / 1920f,
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
    
    public bool TryGetComponent<T>([NotNullWhen(true)] out T? component) where T : UIComponent
    {
        component = GetComponent<T>();
        return component is not null;
    }

    #endregion

    #region Core Methods
    
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
        OnPositionChanged();
        
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
    
    #region Helper Functions

    /// <summary>
    /// Converts a point from the canvas to local position on this element
    /// </summary>
    /// <param name="point">The point to convert</param>
    /// <returns>The converted point</returns>
    protected internal Vector2 ConvertToScaledScreenSpace(Vector2 point)
    {
        return new Vector2(point.X * ScreenScale.X, point.Y * ScreenScale.Y);
    }
    
    protected virtual void OnPositionChanged()
    {
        foreach (var child in Children)
        {
            child.OnPositionChanged();
        }

        if (AnchorPosition == AnchorPosition.Absolute)
        {
            ScaledPosition = Position;
            return;
        }
        
        ScaledPosition = Anchor(Scale(Position));
    }

    protected virtual Rectangle Scale(Rectangle position)
    {
        var scaledParent = Parent!.ScaledPosition;
        var screenScale = ScreenScale;
        var (x, y) = ((int)(position.X * screenScale.X), (int)(position.Y * screenScale.Y));
        var (width, height) = ((int)(position.Width * screenScale.X), (int)(position.Height * screenScale.Y));

        return new Rectangle(x + scaledParent.X, y + scaledParent.Y, width, height);
    }

    protected virtual Rectangle Anchor(Rectangle position)
    {
        var scaledParent = Parent!.ScaledPosition;
        
        Rectangle VTop(Rectangle inp) => inp;
        Rectangle VCenter(Rectangle inp) => new Rectangle(inp.X, scaledParent.Height / 2 - inp.Height / 2 + inp.Y, inp.Width, inp.Height);
        Rectangle VBottom(Rectangle inp) => new Rectangle(inp.X, scaledParent.Height - inp.Height - inp.Y, inp.Width, inp.Height);

        Rectangle HLeft(Rectangle inp) => inp;
        Rectangle HCenter(Rectangle inp) => new Rectangle(scaledParent.Width / 2 - inp.Width / 2 + inp.X, inp.Y, inp.Width, inp.Height);
        Rectangle HRight(Rectangle inp) => new Rectangle(scaledParent.Width - inp.Width - inp.X, inp.Y, inp.Width, inp.Height);


        return AnchorPosition switch
        {
            AnchorPosition.Absolute => position,
            AnchorPosition.TopLeft => VTop(HLeft(position)),
            AnchorPosition.TopCenter => VTop(HCenter(position)),
            AnchorPosition.TopRight => VTop(HRight(position)),
            AnchorPosition.CenterLeft => VCenter(HLeft(position)),
            AnchorPosition.Center => VCenter(HCenter(position)),
            AnchorPosition.CenterRight => VCenter(HRight(position)),
            AnchorPosition.BottomLeft => VBottom(HLeft(position)),
            AnchorPosition.BottomCenter => VBottom(HCenter(position)),
            AnchorPosition.BottomRight => VBottom(HRight(position)),
            _ => throw new ArgumentOutOfRangeException(nameof(AnchorPosition), AnchorPosition, null)
        };
    }

    #endregion

    /// <summary>
    /// TODO: Document
    /// </summary>
    /// <param name="point"></param>
    /// <param name="hit"></param>
    /// <returns></returns>
    public virtual bool Raycast(Vector2 point, out UIElement? hit)
    {
        foreach (var child in Children)
        {
            if (child.Raycast(point, out hit))
            {
                return true;
            }
        }

        if (ScaledPosition.Contains(point))
        {
            hit = this;
            return true;
        }

#if AGGRESSIVE_DEBUG
        if (contains && !children)
        {
            Debug.Log($"Hit {this}");
        }
#endif

        hit = null;
        
        return false;
    }

    #endregion
}