using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.InputSystem;

public class Bindings
{
    private Dictionary<string, Binding> bindings;
    
    public Binding this[string name]
    {
        get => bindings[name];
        private set => bindings[name] = value;
    }
    
    public Bindings()
    {
        bindings = new Dictionary<string, Binding>();
    }
    
    public unsafe void SetBinding(string name, Keys[] keys, BindingType bindingType = BindingType.Button)
    {
        bindings.Add(name, new Binding(bindingType, keys));
    }

    public void AddBinding(string name, Keys key)
    {
        var binding = bindings[name];
        if (binding.Keys != null)
        {
            var keys = binding.Keys.Append(key).ToArray();
            bindings[name] = new Binding(binding.Type, keys);
        }
        else
        {
            bindings[name] = new Binding(binding.Type, new[] {key});
        }
    }

    public Binding GetBinding(string name)
    {
        return bindings[name];
    }
}