using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    /// <summary>
    /// Backing class which controls combat behaviors attached to characters. For example, we might reskin "heavy" for multiple characters.
    /// </summary>
    public abstract record Archetype
    {
        public static readonly DebugArchetype DebugArchetype = new();
        /// <summary>
        /// Selects a <see cref="Move"/>, theoretically but not necessarily from this archetype's <see cref="Moves">move list</see>,
        /// for this character to play, if AI-controlled.
        /// </summary>
        /// <returns>The selected <see cref="Move"/>.</returns>
        public abstract Move SelectMove();
        /// <summary>
        /// A list of <see cref="Move">Moves</see> available to a character with this archetype.
        /// </summary>
        public virtual List<Move> Moves { get; set; }
    }
    /// <summary>
    /// Archetype used for basic testing purposes.
    /// </summary>
    public record DebugArchetype : Archetype
    {
        public override Move SelectMove() => new DebugMove("Debug move");
    }
}
