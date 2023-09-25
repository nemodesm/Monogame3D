using System;
using System.Collections.Generic;
using System.Linq;

namespace Monogame3D.InputSystem;

/// <summary>
/// A virtual input that is represented as a int that is either -1, 0, or 1
/// </summary>
public class VirtualIntegerAxis : VirtualInput
{
    public List<VirtualAxis.Node> Nodes;

    public int Value;
    public int PreviousValue { get; private set; }

    public VirtualIntegerAxis()
    {
        Nodes = new List<VirtualAxis.Node>();
    }

    public VirtualIntegerAxis(params VirtualAxis.Node[] nodes)
    {
        Nodes = new List<VirtualAxis.Node>(nodes);
    }

    public override void Update()
    {
        foreach (var node in Nodes)
            node.Update();

        PreviousValue = Value;
        Value = 0;
        foreach (var value in Nodes.Select(node => node.Value).Where(value => value != 0))
        {
            Value = Math.Sign(value);
            break;
        }
    }

    public static implicit operator int(VirtualIntegerAxis axis)
    {
        return axis.Value;
    }
}