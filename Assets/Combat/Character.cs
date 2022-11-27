using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// Class representing a single unique character.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// The name of this character. Should be unique.
        /// </summary>
        public string Name;
        /// <summary>
        /// The texture this character uses.
        /// </summary>
        public Texture2D Sprite;
        /// <summary>
        /// This character's <see cref="Archetype"/>, which controls which moves it can play during gameplay.
        /// </summary>
        public Archetype Archetype;
        /// <summary>
        /// This character's <see cref="Faction"/>, which determines whether it is player-controlled during gameplay.
        /// </summary>
        public Faction Faction;
        /// <summary>
        /// Whether the player can control this character.
        /// </summary>
        public bool IsPlayerControlled => Faction == GameManager.PlayerFaction;
        public Character(string name, Texture2D sprite, Archetype archetype, Faction faction)
        {
            Name = name;
            Sprite = sprite;
            Archetype = archetype;
            Faction = faction;
        }
        /// <summary>
        /// Called to have this character perform its role in the turn. If player-controlled, awaits player input;
        /// otherwise, its <see cref="JamazonBrine.Archetype"/> selects a move and the character plays it.
        /// </summary>
        public void DoTurn()
        {
            if(IsPlayerControlled)
            {
                Debug.Log($"\t\tAwaiting player input for character {Name}...");
            }
            else
            {
                Debug.Log($"\t\tCharacter {Name} selects move {Archetype.SelectMove()}.");
            }
        }
    }    
}