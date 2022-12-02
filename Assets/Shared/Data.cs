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
            new("#C076DC", Texture2D.whiteTexture, Archetype.Basic, Faction.YamazonCrime),
            new("Yalexa", Texture2D.whiteTexture, Archetype.Drone, Faction.YamazonCrime),
            new("Wiktor", Texture2D.whiteTexture, Archetype.Basic, Faction.Civilian),
            new("Yukio", Texture2D.whiteTexture, Archetype.Heavy, Faction.Civilian),
            new("Alice", Texture2D.whiteTexture, Archetype.Drone, Faction.Civilian)
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
            new("The Slums", 
                winCondition: delegate(CombatScenario scenario)
                {
                    if (scenario.CharactersOn(Side.Left).All(x => x.Defeated)) return ScenarioStatus.RightWon;
                    if (scenario.CharactersOn(Side.Right).All(x => x.Defeated)) return ScenarioStatus.LeftWon;
                    return ScenarioStatus.Ongoing;
                }, 
                ("#C076DC", new(Side.Left, 1)),
                ("Yalexa", new(Side.Left, 2)),
                ("Wiktor", new(Side.Right, 1)),
                ("Yukio", new(Side.Right, 2)),
                ("Alice", new(Side.Right, 3))
               ),
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
