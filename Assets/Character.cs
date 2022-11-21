using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        // Start is called before the first frame update
        void Start()
        {
            if (Def is null) throw new Exception("An instance of the Character monobehaviour has a null def at start. Make sure to assign the Def " +
                                                 "field immediately after instantiating.");
            Sprite.sprite = Def.Texture.ToSprite();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
