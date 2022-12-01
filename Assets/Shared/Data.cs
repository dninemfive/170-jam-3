using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// Stores the actual character, scene, &c data. Might be changed to load these from json in the future.
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// A list of all <see cref="Character"/>s in the game. Used to populate the <see cref="Characters"/> dictionary.
        /// </summary>
        private static readonly List<Character> characters = new()
        {
            new("Jim", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Good),
            new("Liz", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Good),
            new("Bob", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Good),
            new("Bront", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Bad),
            new("Alice", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Bad),
            new("James", Texture2D.whiteTexture, Archetype.DebugArchetype, Faction.Bad)
        };
        /// <summary>
        /// All <see cref="Character"/>s in the game, indexed by name.
        /// </summary>
        public static readonly Dictionary<string, Character> Characters = new();
        /// <summary>
        /// A list of all <see cref="CombatScenario"/>s in the game. Used to populate the <see cref="Scenarios"/> enumerable.
        /// </summary>
        private static readonly List<CombatScenario> scenarios = new()
        {
            new("Debug Scene", 
                (CombatScenario _) => GameManager.RoundNumber > 1 ? SceneStatus.Ongoing : SceneStatus.NeitherWon, 
                ("Jim", new(Side.Left, 1)),
                ("Liz", new(Side.Left, 2)),
                ("Bob", new(Side.Left, 3)),
                ("Bront", new(Side.Right, 1)),
                ("Alice", new(Side.Right, 2))
               )
        };
        /// <summary>
        /// All scenes in the game, in order. As an enumerable to avoid modifying <see cref="scenarios"/> during gameplay.
        /// </summary>
        public static IEnumerable<CombatScenario> Scenarios
        {
            get
            {
                foreach (CombatScenario scenario in scenarios) yield return scenario;
            }
        }
        /// <summary>
        /// Static constructor for <see cref="Data"/>. Populates the <see cref="Characters"/> dictionary when called.
        /// </summary>
        static Data()
        {
            foreach (Character character in characters)
            {
                if (Characters.ContainsKey(character.Name)) throw new Exception($"Tried to add {character} to the database but a character with that name already exists.");
                Characters.Add(character.Name, character);
            }
        }
    }
}
