using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame3D.UI
{
    // ReSharper disable once InconsistentNaming
    public class UIElement : ICanvasDrawable, IUpdateable
    {
        protected readonly HashSet<UIElement> _childUiElements = new();
        /// <summary>
        /// The list of components that are attached to this UI element
        /// </summary>
        protected readonly HashSet<UIComponent> _components = new();

        private UIElement _parent;
        protected internal Canvas Canvas => _parent is null ? this as Canvas : _parent.Canvas;

        public virtual AnchorPosition AnchorPosition { get; set; }
        public virtual Vector2 Offset { get; set; }

        public UIElement(params UIComponent[] components)
        {
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
            this._components.Add(component);
            
            component.Initialise();
        }

        /// <summary>
        /// Adds a new UI Element as a child of this one
        /// </summary>
        /// <param name="element">The element to add as child</param>
        public void AddElement(UIElement element)
        {
            element._parent = this;
            _childUiElements.Add(element);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            foreach (var uiElement in _childUiElements)
            {
                uiElement.Draw(gameTime, spriteBatch);
            }
        }

        public void Initialize()
        {
            foreach (var element in _childUiElements)
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
            foreach (var element in _childUiElements)
            {
                element.Update(gameTime);
            }

            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public bool Enabled { get; set; }
        public int UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
    }
}
