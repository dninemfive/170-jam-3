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
        public static readonly DebugArchetype Debug = new();
        public static readonly BasicArchetype Basic = new();
        public static readonly HeavyArchetype Heavy = new();
        public static readonly DroneArchetype Drone = new();
        /// <summary>
        /// Selects a <see cref="Move"/>, theoretically but not necessarily from this archetype's <see cref="Moves">move list</see>,
        /// for this character to play, if AI-controlled.
        /// </summary>
        /// <returns>The selected <see cref="Move"/>.</returns>
        public virtual Move SelectMove() => Moves.Random();
        /// <summary>
        /// A list of <see cref="Move">Moves</see> available to a character with this archetype.
        /// </summary>
        public virtual List<Move> Moves { get; }
        public virtual List<(Stat stat, int MaxValue)> Stats => new()
        {
            (Stat.Health, 10),
            (Stat.Conviction, 10)
        };
    }
    /// <summary>
    /// Archetype used for basic testing purposes.
    /// </summary>
    public record DebugArchetype : Archetype
    {
        public override List<Move> Moves => new()
        {
            new DebugMove("Debug move")
        };
    }
    public record BasicArchetype : Archetype
    {
        public override List<Move> Moves => new()
        {
            new Attack("Strike", 10, Attack.StatType.Health),
            new Attack("Convince", 7, Attack.StatType.Conviction)
        };
    }
    public record HeavyArchetype : Archetype
    {
        public override List<Move> Moves => new()
        {
            new Attack("Strike", 15, Attack.StatType.Health),
            new Attack("Convince", 4, Attack.StatType.Conviction)
        };
    }
    public record DroneArchetype : Archetype
    {
        public override List<Move> Moves => new()
        {
            new Attack("Zap", 5, Attack.StatType.Health)
        };
    }
}
