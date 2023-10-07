using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame3D;

/// <summary>
/// An Element that can is part of a hierarchy of elements
/// </summary>
/// <typeparam name="T">T is the type of this hierarchy tree</typeparam>
public class HierarchyElement<T> : GameElement, IEnumerable<T> where T : HierarchyElement<T>
{
    #region Fields

    /// <summary>
    /// This element' parent object. Will be null if this is a root element
    /// </summary>
    protected T? Parent;
    
    /// <summary>
    /// The list of all child UI elements
    /// </summary>
    protected List<T> Children = new();
    
    /// <summary>
    /// The number of children this element has
    /// </summary>
    public int ChildCount => Children.Count;

    #endregion

    #region Hierarchy Methods

    #region Modification
    
    /// <summary>
    /// Adds a new UI Element as a child of this one
    /// </summary>
    /// <param name="element">The element to add as child</param>
    public void AddElement(T element)
    {
        element.Parent = (T?)this;
        Children.Add(element);
    }

    /// <summary>
    /// Removes the UI Element from the canvas
    /// </summary>
    /// <param name="element">The element to remove as child</param>
    public void RemoveElement(T element)
    {
        if (element.Parent != this)
        {
            Debug.LogError(new InvalidOperationException(
                $"Attempted to remove {element} from children of {this} when it was not a child to " +
                "begin with"));
        }
        element.Parent = null;
        Children.Remove(element);
    }

    #endregion
    
    #region Navigation

    /// <summary>
    /// Returns the child at the given index
    /// </summary>
    /// <param name="i">The index of the child to return</param>
    /// <returns>The child</returns>
    public T? GetChild(int i) => i < Children.Count ? Children[i] : null;

    /// <summary>
    /// Returns the first child that has the given name
    /// </summary>
    /// <param name="name">The name to look for</param>
    /// <returns>The first child that matches the given name</returns>
    public T? GetChildByName(string name)
    {
        foreach (var child in Children)
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
    
    public override void Update(GameTime gameTime)
    {
        if (!this.Enabled)
            return;

        foreach (var element in Children)
        {
            element.Update(gameTime);
        }
    }

    #region IEnumerator Implementation

    public IEnumerator<T> GetEnumerator() => Children.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}