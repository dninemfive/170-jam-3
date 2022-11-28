using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

namespace JamazonBrine
{
    public class CharacterDisplayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject CharacterPrefab;
        [SerializeField]
        private Side Side;
        public void LoadScenario(CombatScenario scenario)
        {
            List<Character> characters = scenario.CharactersOn(Side).ToList();
            Rect rect = GetComponent<RectTransform>().rect;
            float offset = rect.height / characters.Count, totalOffset = offset;
            foreach(Character c in characters)
            {
                c.InstantiateCharacter(CharacterPrefab);
                Vector3 tf = new(transform.position.x, rect.yMax - totalOffset);
                totalOffset += offset;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
