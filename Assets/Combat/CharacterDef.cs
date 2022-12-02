using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// Class representing a single unique character.
    /// </summary>
    /// <remarks>Not a MonoBehavior because this is used for <see cref="Data"/>. Should probably split these up?</remarks>
    public record CharacterDef
    {
        /// <summary>
        /// The name of this character. Should be unique.
        /// </summary>
        public string Name;
        /// <summary>
        /// The texture this character uses.
        /// </summary>
        public Texture2D Texture;
        /// <summary>
        /// This character's <see cref="Archetype"/>, which controls which moves it can play during gameplay.
        /// </summary>
        public Archetype Archetype;
        /// <summary>
        /// This character's <see cref="Faction"/>, which determines whether it is player-controlled during gameplay.
        /// </summary>
        public Faction Faction;        
        public CharacterDef(string name, Texture2D sprite, Archetype archetype, Faction faction)
        {
            Name = name;
            Texture = sprite;
            Archetype = archetype;
            Faction = faction;
        }        
    }    
}