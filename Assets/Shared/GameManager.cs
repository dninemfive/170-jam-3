using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

namespace JamazonBrine 
{
    /// <summary>
    /// The <see cref="MonoBehaviour"/> used to bootstrap the rest of the game logic. Contains the core code for gameplay.
    /// </summary>
    public static class GameManager
    {
        private static CombatScenario currentScenario = null;
        /// <summary>
        /// The current <see cref="CombatScenario"/> being played.
        /// </summary>
        public static CombatScenario CurrentScenario {
            get => currentScenario;
            set
            {
                Debug.Log($"Setting current scenario to {value.Name}");
                currentScenario = value;
                CombatUIManager.LoadCurrentScenario();
                RoundManager.BeginScenario();
            }
        }
        /// <summary>
        /// The <see cref="Faction"/> which the player controls during combat.
        /// </summary>
        public static Faction PlayerFaction = Faction.Good;
        /// <summary>
        /// Whether a <see cref="Bootstrapper"/> class has initialized the <c>GameManager.</c>
        /// </summary>
        public static bool Initialized { get; private set; } = false;
        public static ScenarioStatus CurrentSceneStatus { get; private set; }
        /// <summary>
        /// Begins the <see cref="GameManager"/>'s execution of the scenes described in <see cref="Data.scenarios"/>.
        /// </summary>
        public static void Init()
        {
            if (Initialized) return;
            Initialized = true;
            Debug.Log("Initialized GameManager");
        }
        public static void GoToMainMenu() => Utils.LoadScene("MainMenu");
        public static void GoToCombatScene() => Utils.LoadScene("Combat");
    }
}
