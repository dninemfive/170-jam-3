using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// The base definition of a Move, which is any action a character can perform in combat.
    /// </summary>
    public abstract record Move
    {
        public static readonly DebugMove DebugMove = new("Debug move");
        /// <summary>
        /// The move's display name. Ideally, unique, however this is not (yet?) enforced.
        /// </summary>
        public string Name;
        public Move(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Executes the effects of the move.
        /// </summary>
        public abstract void Execute();
        public override string ToString() => Name;
    }
    /// <summary>
    /// A simple debug move, used for testing.
    /// </summary>
    public record DebugMove : Move
    {
        public DebugMove(string n) : base(n) { }
        public override void Execute()
        {
            Debug.Log($"Executing {this}!");
        }
    }
}
