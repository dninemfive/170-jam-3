using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// Class representing a single unique character.
    /// </summary>
    public class Character : MonoBehaviour
    {
        public string Name;
        public Texture2D Sprite;
        public Archetype Archetype;
        public Faction Faction;
        public bool IsPlayerControlled => Faction == GameManager.PlayerFaction;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void DoTurn()
        {
            if(IsPlayerControlled)
            {
                Debug.Log($"\t\tAwaiting player input for character {Name}...");
            }
            else
            {
                Debug.Log($"\t\tCharacter {name} selects move {Archetype.SelectMove()}.");
            }
        }
    }    
}