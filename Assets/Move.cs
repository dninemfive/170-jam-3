using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    public abstract record Move
    {
        public static readonly DebugMove DebugMove = new("Debug move");
        public string Name;
        public Move(string name)
        {
            Name = name;
        }
        public abstract void Execute();
        public override string ToString() => Name;
    }
    public record DebugMove : Move
    {
        public DebugMove(string n) : base(n) { }
        public override void Execute()
        {
            Debug.Log($"Executing {this}!");
        }
    }
}
