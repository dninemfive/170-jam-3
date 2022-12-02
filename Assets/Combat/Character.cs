using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public Texture2D Texture;
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
        public Character(string name, Texture2D texture, Archetype archetype, Faction faction)
        {
            Name = name;
            Texture = texture;
            Archetype = archetype;
            Faction = faction;
            foreach((Stat stat, int maxValue) in Archetype.Stats)
            {
                stats.Add(stat, new(stat, maxValue, this));
            }
        }
        /// <summary>
        /// Called to have this character perform its role in the turn. If player-controlled, awaits player input;
        /// otherwise, its <see cref="JamazonBrine.Archetype"/> selects a move and the character plays it.
        /// </summary>
        public void DoTurn()
        {
            CombatUIManager.MoveDisplayer.LoadMoves(this);
            if(IsPlayerControlled)
            {
                //Debug.Log($"Awaiting player input for character {RoundManager.CharacterIndex} ({Name})...");
            }
            else
            {
                //Debug.Log($"Character {RoundManager.CharacterIndex} ({Name}) selects move {Archetype.SelectMove()}.");
            }
        }
        public Side? Side
        {
            get
            {
                foreach (Side side in Utils.AllSides) if (RoundManager.CurrentScenario.CharactersOn(side).Contains(this)) return side;
                return null;
            }
        }
        private readonly Dictionary<Stat, StatTracker> stats = new();
        public StatTracker this[Stat stat] => stats[stat];
        public override string ToString() => Name;
    }    
}