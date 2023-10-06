using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public class UIElement : GameElement, ICanvasDrawable, IUpdateable
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

    #endregion

    #region Positioning
    
    /// <summary>
    /// Where this UI element is anchored to relative to the parent element
    /// </summary>
    public virtual AnchorPosition AnchorPosition { get; set; }

    /// <summary>
    /// The bounding rectangle of this UI element as it would appear on a 1920x1080 screen
    /// </summary>
    public virtual Rectangle Position { get; set; } = new(0, 0, 100, 100);
    
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
            
            var scaledParent = _parent!.ScaledPosition;
            var (screenWidthRatio, screenHeightRatio) = (Engine.Graphics.PreferredBackBufferWidth / 1920f, Engine.Graphics.PreferredBackBufferHeight / 1080f);
            var (x, y) = ((int)(Position.X * screenWidthRatio), (int)(Position.Y * screenHeightRatio));
            var (width, height) = ((int)(Position.Width * screenWidthRatio), (int)(Position.Height * screenHeightRatio));
            
            return AnchorPosition switch
            {
                AnchorPosition.TopLeft => new(x + scaledParent.X, y + scaledParent.Y, width, height),
                AnchorPosition.TopCenter => new(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.TopRight => new(
                    scaledParent.Width - width - x + scaledParent.X,
                    y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.CenterLeft => new(
                    x + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.Center => new(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.CenterRight => new(
                    scaledParent.Width - width - x + scaledParent.X,
                    scaledParent.Height / 2 - height / 2 + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomLeft => new(
                    x + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomCenter => new(
                    scaledParent.Width / 2 - width / 2 + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                AnchorPosition.BottomRight => new(
                    scaledParent.Width - width - x + scaledParent.X,
                    scaledParent.Height - height - y + scaledParent.Y,
                    width,
                    height),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    #endregion

    #region Hierarchy

    private UIElement? _parent;
    
    protected internal Canvas Canvas => (_parent is null ? this as Canvas : _parent.Canvas)!;
    
    /// <summary>
    /// The list of all child UI elements
    /// </summary>
    protected readonly List<UIElement> ChildUIElements = new();
    
    /// <summary>
    /// The number of children this element has
    /// </summary>
    public int ChildCount => ChildUIElements.Count;

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
        this.Name = name;
            
        foreach (var component in components)
        {
            component.Element = this;
            Components.Add(component);
        }
    }
    public UIElement(string name, Rectangle position, params UIComponent[] components) : this(name, components)
    {
        this.Position = position;
    }
    
    [Obsolete(message: "Support for copying properties from one UI element to another was removed in alpha dev 3, any newer feature will not be copied")]
    public UIElement(UIElement uiElement)
    {
        this.Name = uiElement.Name;
        // ReSharper disable once VirtualMemberCallInConstructor
        this.AnchorPosition = uiElement.AnchorPosition;
        this.Enabled = uiElement.Enabled;
        this.UpdateOrder = uiElement.UpdateOrder;
        this._parent = uiElement._parent;
        this.ChildUIElements = uiElement.ChildUIElements;
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

    #region Hierarchy

    #region Modification
    
    /// <summary>
    /// Adds a new UI Element as a child of this one
    /// </summary>
    /// <param name="element">The element to add as child</param>
    public void AddElement(UIElement element)
    {
        element._parent = this;
        ChildUIElements.Add(element);
    }

    /// <summary>
    /// Removes the UI Element from the canvas
    /// </summary>
    /// <param name="element">The element to remove as child</param>
    public void RemoveElement(UIElement element)
    {
        if (element._parent != this)
        {
            Debug.LogError(new InvalidOperationException(
                $"Attempted to remove {element} from children of {this} when it was not a child to " +
                "begin with"));
        }
        element._parent = null;
        ChildUIElements.Remove(element);
    }

    #endregion
    
    #region Navigation

    /// <summary>
    /// Returns the child at the given index
    /// </summary>
    /// <param name="i">The index of the child to return</param>
    /// <returns>The child</returns>
    public UIElement? GetChild(int i) => i < ChildUIElements.Count ? ChildUIElements[i] : null;

    /// <summary>
    /// Returns the first child that has the given name
    /// </summary>
    /// <param name="name">The name to look for</param>
    /// <returns>The first child that matches the given name</returns>
    public UIElement? GetChildByName(string name)
    {
        foreach (var child in ChildUIElements)
        {
            if (child.Name == name)
            {
                return child;
            }
        }

        return null;
    }

    #endregion

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

        foreach (var uiElement in ChildUIElements)
        {
            if (uiElement.Enabled)
            {
                uiElement.Draw(gameTime, spriteBatch);
            }
        }
    }

    public void Initialize()
    {
        foreach (var element in ChildUIElements)
        {
            element.Initialize();
        }

        foreach (var component in Components)
        {
            component.Initialise();
        }
    }

    public override void Update(GameTime gameTime)
    {
        if (!this.Enabled)
        {
            return;
        }
        
        foreach (var element in ChildUIElements)
        {
            element.Update(gameTime);
        }

        foreach (var component in Components)
        {
            component.Update(gameTime);
        }
    }

    #endregion
}