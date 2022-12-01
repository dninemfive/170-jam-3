using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamazonBrine
{
    public class CombatUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject leftCharacterDisplayPanel;
        public static CharacterDisplayer LeftCharacterDisplayer => Instance.leftCharacterDisplayPanel.GetComponent<CharacterDisplayer>();
        public static CombatUIManager Instance { get; private set; } = null;
        // Start is called before the first frame update
        void Start()
        {
            if(Instance is not null)
            {
                Debug.LogWarning($"Initializing CombatUIManager on object {gameObject.name}, but an Instance thereof already exists!");
            }
            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
