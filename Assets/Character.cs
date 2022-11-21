using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace JamazonBrine
{
    /// <summary>
    /// <see cref="MonoBehaviour"/> which connects a character's Def to its sprite and adjusts it accordingly.
    /// </summary>
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="CharacterDef"/> corresponding to this character, holding metadata like the name and archetype.
        /// </summary>
        public CharacterDef Def = null;
        /// <summary>
        /// Used to cache this character's <c>SpriteRenderer</c> for better performance.
        /// </summary>
        private SpriteRenderer sprite = null;
        /// <summary>
        /// Gets this character's <c>SpriteRenderer</c>, caching it if it has not yet been cached.
        /// </summary>
        public SpriteRenderer Sprite
        {
            get
            {
                if (sprite is null)
                {
                    sprite = GetComponent<SpriteRenderer>();
                }
                return sprite;
            }
        }
        private TextMeshProUGUI nameText = null;
        public TextMeshProUGUI NameText
        {
            get
            {
                if(nameText is null)
                {
                    nameText = transform.Find("Canvas/Name").GetComponent<TextMeshProUGUI>();
                }
                return nameText;
            }
        }
        /// <summary>
        /// Whether the player can control this character.
        /// </summary>
        public bool IsPlayerControlled => Def.Faction == GameManager.PlayerFaction;
        /// <summary>
        /// Called to have this character perform its role in the turn. If player-controlled, awaits player input;
        /// otherwise, its <see cref="JamazonBrine.Archetype"/> selects a move and the character plays it.
        /// </summary>
        public void DoTurn()
        {
            if (IsPlayerControlled)
            {
                Debug.Log($"\t\tAwaiting player input for character {Def.Name}...");
            }
            else
            {
                Debug.Log($"\t\tCharacter {Def.Name} selects move {Def.Archetype.SelectMove()}.");
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            if (Def is null) throw new Exception("An instance of the Character monobehaviour has a null def at start. Make sure to assign the Def " +
                                                 "field immediately after instantiating.");
            Sprite.sprite = Def.Texture.ToSprite();
            /* todo: see if weird scaling is still an issue once we have actual sprites
            Debug.Log($"{Sprite.transform} {Sprite.bounds} {Sprite.localBounds}");
            Sprite.localBounds = new(new(0, 0, 0), new(1, 1, 1));
            Debug.Log($"{Sprite.transform} {Sprite.bounds} {Sprite.localBounds}");     
            */
            NameText.text = Def.Name;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
