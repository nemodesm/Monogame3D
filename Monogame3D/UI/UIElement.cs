using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI;

public class UIElement : ICanvasDrawable, IUpdateable
{
    public string name;
    protected readonly List<UIElement> _childUIElements = new();
    /// <summary>
    /// The list of components that are attached to this UI element
    /// </summary>
    protected readonly HashSet<UIComponent> _components = new();

    private UIElement _parent;
    private bool _enabled;
    protected internal Canvas Canvas => _parent is null ? this as Canvas : _parent.Canvas;
    protected static Engine Engine => Engine.Instance;

    public virtual AnchorPosition AnchorPosition { get; set; }
    public virtual Vector2 Offset { get; set; }
    public int ChildCount => _childUIElements.Count;

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
        this.name = name;
            
        foreach (var component in components)
        {
            component.UIElement = this;
            _components.Add(component);
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
        _components.Add(component);
            
        component.Initialise();
    }

    /// <summary>
    /// Adds a new UI Element as a child of this one
    /// </summary>
    /// <param name="element">The element to add as child</param>
    public void AddElement(UIElement element)
    {
        element._parent = this;
        _childUIElements.Add(element);
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
        _childUIElements.Remove(element);
    }
        
    public UIElement GetChild(int i)
    {
        if (i < _childUIElements.Count) return _childUIElements[i];
        Debug.LogError(
            $"Could not get child at index{i} from UI element with only {_childUIElements.Count} children");
        return null;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (var component in _components)
        {
            component.Draw(gameTime, spriteBatch);
        }

        foreach (var uiElement in _childUIElements)
        {
            uiElement.Draw(gameTime, spriteBatch);
        }
    }

    public void Initialize()
    {
        foreach (var element in _childUIElements)
        {
            element.Initialize();
        }

        foreach (var component in _components)
        {
            component.Initialise();
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (var element in _childUIElements)
        {
            element.Update(gameTime);
        }

        foreach (var component in _components)
        {
            component.Update(gameTime);
        }
    }

    public T GetComponent<T>() where T : UIComponent
    {
        foreach (var component in _components)
        {
            if (component is T t)
            {
                return t;
            }
        }

        return null;
    }
}