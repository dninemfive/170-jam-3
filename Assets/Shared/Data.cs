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
        /// A list of all <see cref="CombatScenario"/>s in the game. Used to populate the <see cref="Scenes"/> enumerable.
        /// </summary>
        private static readonly List<CombatScenario> scenes = new()
        {
            new("Debug Scene", 
                (CombatScenario _) => GameManager.RoundNumber > 1 ? SceneStatus.Ongoing : SceneStatus.NeitherWon, 
                ("Jim", new(Side.Left, 1)), 
                ("Bront", new(Side.Right, 1))
               )
        };
        /// <summary>
        /// All scenes in the game, in order. As an enumerable to avoid modifying <see cref="scenes"/> during gameplay.
        /// </summary>
        public static IEnumerable<CombatScenario> Scenes
        {
            get
            {
                foreach (CombatScenario scene in scenes) yield return scene;
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
