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
        private readonly List<GameObject> CurrentCharacters = new();
        public void LoadScenario(CombatScenario scenario)
        {
            ClearCurrentCharacters();
            List<Character> characters = scenario.CharactersOn(Side).ToList();
            float height = GetComponent<RectTransform>().rect.height;
            float offset = height / (characters.Count + 1), totalOffset = offset;
            foreach(Character c in characters)
            {
                PlaceCharacter(c, totalOffset, height);
                totalOffset += offset;
            }
        }
        public void ClearCurrentCharacters()
        {
            Debug.Log($"Clearing {CurrentCharacters.Count} existing characters from the {Side} character displayer...");
            foreach (GameObject go in CurrentCharacters) Destroy(go);
            CurrentCharacters.Clear();
        }
        private void PlaceCharacter(Character c, float totalOffset, float height)
        {           
            GameObject co = c.Instantiate(CharacterPrefab);
            CurrentCharacters.Add(co);
            co.transform.SetParent(transform);
            Vector3 tf = new(transform.position.x, height - totalOffset);                 
            co.transform.position = tf;
            Debug.Log($"Placed character {c.Name} at {tf}");
        }
    }
}
