using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame3D.UI;

public class UIElement : ICanvasDrawable, IUpdateable
{
    /// <summary>
    /// The name of this UI element
    /// </summary>
    /// <remarks>
    /// No checks are made to ensure that this name is unique in the UI tree
    /// </remarks>
    public string Name;
    
    /// <summary>
    /// The list of all child UI elements
    /// </summary>
    protected readonly List<UIElement> ChildUIElements = new();
    
    /// <summary>
    /// The list of components that are attached to this UI element
    /// </summary>
    protected readonly HashSet<UIComponent> Components = new();

    private UIElement? _parent;
    private bool _enabled = true;
    protected internal Canvas Canvas => (_parent is null ? this as Canvas : _parent.Canvas)!;
    protected static Engine Engine => Engine.Instance;

    public virtual AnchorPosition AnchorPosition { get; set; }
    public virtual Vector2 Offset { get; set; }
    public int ChildCount => ChildUIElements.Count;

    public bool Enabled
    {
        get => _enabled;
        set
        {
            EnabledChanged?.Invoke(this, EventArgs.Empty);
            _enabled = value;
        }
    }

    public int UpdateOrder => 0;
    public event EventHandler<EventArgs> EnabledChanged;
    public event EventHandler<EventArgs> UpdateOrderChanged;

    public UIElement(params UIComponent[] components) : this("New UI Element", components) { }
    public UIElement(string name, params UIComponent[] components)
    {
        this.Name = name;
            
        foreach (var component in components)
        {
            component.UIElement = this;
            Components.Add(component);
        }
    }
        
    public UIElement(UIElement uiElement)
    {
        // TODO: Copy properties from element passed as argument
    }

    /// <summary>
    /// Adds a component to this UI Element
    /// </summary>
    /// <param name="component">The component to add to this element</param>
    public virtual void AddComponent(UIComponent component)
    {
        if (component.UIElement != this && component.UIElement is not null)
        {
            Debug.LogError(new InvalidOperationException());
        }
        component.UIElement = this;
        Components.Add(component);
            
        component.Initialise();
    }

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
    
    public UIElement? GetChild(int i)
    {
        if (i < ChildUIElements.Count)
        {
            return ChildUIElements[i];
        }
        
        return null;
    }
    
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

    public void Update(GameTime gameTime)
    {
        foreach (var element in ChildUIElements)
        {
            element.Update(gameTime);
        }

        foreach (var component in Components)
        {
            component.Update(gameTime);
        }
    }

    public T GetComponent<T>() where T : UIComponent
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
}