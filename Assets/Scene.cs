using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    public enum Side { Left, Right }
    public record CharacterLocation
    {
        Side Side;
        int Order;
        public CharacterLocation(Side side, int order)
        {
            Side = side;
            Order = order;
        }
    }
    public class Scene
    {
        public string Name;
        private Dictionary<CharacterLocation, Character> CharactersPresent = new();
        public Character this[CharacterLocation loc] => CharactersPresent[loc];
        public Character this[Side side, int order] => CharactersPresent[new(side, order)];
        public void Add(Character character, CharacterLocation location)
        {
            if (CharactersPresent.Values.Contains(character)) throw new Exception($"The scene {Name} already contains the character {character.Name}!");
            if (CharactersPresent.ContainsKey(location)) throw new Exception($"The scene {Name} already contains a character at {location}!");
            CharactersPresent[location] = character;
        }
    }
}
