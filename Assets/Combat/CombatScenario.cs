using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{     
    /// <summary>
    /// Describes a single scene, or level, of gameplay.
    /// </summary>
    public class CombatScenario
    {
        /// <summary>
        /// This scene's name. Not (yet?) used.
        /// </summary>
        public string Name;
        /// <summary>
        /// The characters present in the scene, indexed by their locations. <c>private</c> so that it cannot be modified during gameplay,
        /// as the <c>readonly</c> modifier does not prevent modifying the variable, only overwriting it.
        /// </summary>
        private readonly Dictionary<CharacterLocation, Character> CharactersPresent = new();
        /// <summary>
        /// Gets the <see cref="Character"/> at the specified <see cref="CharacterLocation"/> in this scene.
        /// </summary>
        /// <param name="loc">The location whose character to find.</param>
        /// <returns>The <see cref="Character"/> at the specified location. Will throw an error if no character is at that location!</returns>
        public Character this[CharacterLocation loc] => CharactersPresent[loc];
        /// <summary>
        /// Gets the <see cref="Character"/> on the specified <see cref="Side"/> and order.
        /// </summary>
        /// <param name="side">The side on which the character is located.</param>
        /// <param name="order">The position the character occupies in the order.</param>
        /// <returns>The <see cref="Character"/> at the specified location.</returns>
        /// <remarks>Will throw an error if no character is at that location!</remarks>
        public Character this[Side side, int order] => CharactersPresent[new(side, order)];
        /// <summary>
        /// The <see cref="Side"/> which goes first in this scene.
        /// </summary>
        public Side StartingSide;
        /// <summary>
        /// The <see cref="Character"/>s present on the specified <see cref="Side"/> in this scene.
        /// </summary>
        /// <param name="side">The <see cref="Side"/> whose <see cref="Character"/>s to return.</param>
        /// <returns>The <see cref="Character"/>s on the specified <see cref="Side"/>.</returns>
        public IEnumerable<Character> CharactersOn(Side side) => CharactersPresent
            .Where(x => x.Key.Side == side)
            .OrderBy(x => x.Key.Order)
            .Select(x => x.Value);
        /// <summary>
        /// A delegate type which determines the winner, if any, of a given scene.
        /// </summary>
        /// <param name="scene">The scene whose conditions to check.</param>
        /// <returns>The <see cref="SceneStatus">status</see> of the current scene.</returns>
        public delegate SceneStatus WinConditionChecker(CombatScenario scene);
        /// <summary>
        /// The <see cref="WinConditionChecker">win condition</see> for this particular scene.
        /// </summary>
        public WinConditionChecker WinCondition;
        /// <summary>
        /// Checks the <see cref="WinCondition">WinCondition</see> for this scene. See <see cref="WinConditionChecker"/> for more details.
        /// </summary>
        public SceneStatus CheckWinCondition => WinCondition(this);
        /// <summary>
        /// Stores the names and locations of the characters in this scene until it's loaded.
        /// </summary>
        private readonly List<(string name, CharacterLocation location)> characterLocations;
        /// <summary>
        /// Creates a new scene with the specified parameters.
        /// </summary>
        /// <param name="name">The name of this scene; currently unused.</param>
        /// <param name="checker">The <see cref="WinConditionChecker"/> which determines when the scene concludes.</param>
        /// <param name="_characterLocations">The characters present in the scene. As this is a 
        /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params">params</see> 
        /// argument, these can simply be comma-delimited.</param>
        public CombatScenario(string name, WinConditionChecker checker, params (string name, CharacterLocation location)[] _characterLocations)
        {
            Name = name;
            WinCondition = checker;
            Debug.Log($"Scene {name} has characters {_characterLocations.Select(x => x.name).CommaSeparatedList()}");
            characterLocations = _characterLocations.ToList();
        }
        /// <summary>
        /// Adds a character to this scene, checking that they are uniquely named and positioned.
        /// </summary>
        /// <param name="character">The <see cref="Character"/> to add.</param>
        /// <param name="location">The <see cref="CharacterLocation">location</see> at which to add the character.</param>
        /// <remarks>Throws an error if the character's name is not unique or its location is already filled.</remarks>
        private void Add(Character character, CharacterLocation location)
        {
            Debug.Log($"Trying to add character {character.Name} at {location} in scene {Name}.");
            if (CharactersPresent.Values.Contains(character)) throw new Exception($"The scene {Name} already contains the character {character.Name}!");
            if (CharactersPresent.ContainsKey(location)) throw new Exception($"The scene {Name} already contains a character at {location}!");
            CharactersPresent[location] = character;
        }
        /// <summary>
        /// Loads this scene, updating the UI and populating <see cref="CharactersPresent"/>.
        /// </summary>
        public void Load()
        {
            foreach ((string cName, CharacterLocation location) in characterLocations) Add(Data.Characters[cName], location);
        }
    }
}
