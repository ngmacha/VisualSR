﻿using System;
using System.ComponentModel.Composition;
using VisualSR.Core;

namespace Nodes.Nodes.Math
{
    [Serializable]
    [Export(typeof(Node))]
    public class Floor : Node
    {
        private readonly VirtualControl Host;

        [ImportingConstructor]
        public Floor([Import("host")] VirtualControl host, [Import("bool")] bool spontaneousAddition = false) : base(
            host,
            NodeTypes.Basic,
            spontaneousAddition)
        {
            Host = host;
            Title = "Floor";
            Category = "Math nodes";
            Description = "Calculates floor(x).";
            AddObjectPort(this, "value", PortTypes.Input, RTypes.Numeric, false);
            AddObjectPort(this, "return floor(value)", PortTypes.Output, RTypes.Numeric, true);
            InputPorts[0].DataChanged += (s, e) =>
            {
                OutputPorts[0].Data.Value = "floor(" + InputPorts[0].Data.Value + ")";
            };
        }

        public override string GenerateCode()
        {
            return null;
        }

        public override Node Clone()
        {
            var node = new Floor(Host);

            return node;
        }
    }
}