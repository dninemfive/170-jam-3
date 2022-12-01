using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JamazonBrine
{
    public class CombatUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject leftCharacterDisplayPanel;
        public static CharacterDisplayer LeftCharacterDisplayer => Instance.leftCharacterDisplayPanel.GetComponent<CharacterDisplayer>();
        [SerializeField]
        private GameObject rightCharacterDisplayPanel;
        public static CharacterDisplayer RightCharacterDisplayer => Instance.rightCharacterDisplayPanel.GetComponent<CharacterDisplayer>();
        public static CombatUIManager Instance { get; private set; } = null;
        // Start is called before the first frame update
        void Start()
        {
            if(Instance is not null)
            {
                return;
                // Debug.LogWarning($"Initializing CombatUIManager on object {gameObject.name}, but an Instance thereof already exists!");
            }
            Debug.Log($"Initializing CombatUIManager on object {gameObject.name}...");
            Instance = this;
            if (GameManager.CurrentScenario is null) GameManager.CurrentScenario = Data.Scenarios.First();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public static void LoadCurrentScenario()
        {
            Debug.Log("CombatUIManager.LoadScenario()");
            GameManager.BeginCurrentScenario();
            LeftCharacterDisplayer.LoadScenario(GameManager.CurrentScenario);
            RightCharacterDisplayer.LoadScenario(GameManager.CurrentScenario);
        }
    }
}
