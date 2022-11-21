using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{     
    public class Scene
    {
        public string Name;
        private readonly Dictionary<CharacterLocation, Character> CharactersPresent = new();
        public Character this[CharacterLocation loc] => CharactersPresent[loc];
        public Character this[Side side, int order] => CharactersPresent[new(side, order)];
        public Side StartingSide;
        public IEnumerable<Character> CharactersOn(Side side) => CharactersPresent
            .Where(x => x.Key.Side == side)
            .OrderBy(x => x.Key.Order)
            .Select(x => x.Value);
        public IEnumerable<Character> LeftSideCharacters => CharactersOn(Side.Left);
        public IEnumerable<Character> RightSideCharacters => CharactersOn(Side.Right);
        public delegate Side? WinConditionChecker(Scene scene);
        public WinConditionChecker WinCondition;
        public Side? CheckWinCondition => WinCondition(this);
        public Scene(string name, WinConditionChecker checker, params (string name, CharacterLocation location)[] characterLocations)
        {
            Name = name;
            WinCondition = checker;
            foreach ((string cName, CharacterLocation location) in characterLocations) Add(Data.Characters[cName], location);
        }
        private void Add(Character character, CharacterLocation location)
        {
            if (CharactersPresent.Values.Contains(character)) throw new Exception($"The scene {Name} already contains the character {character.Name}!");
            if (CharactersPresent.ContainsKey(location)) throw new Exception($"The scene {Name} already contains a character at {location}!");
            CharactersPresent[location] = character;
        }
    }
}
