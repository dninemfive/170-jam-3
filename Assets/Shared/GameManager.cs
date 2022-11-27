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
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The current <see cref="CombatScenario"/> being played.
        /// </summary>
        public static CombatScenario CurrentScene;
        /// <summary>
        /// The number of rounds which have elapsed, including the current round. Starts at 1.
        /// </summary>
        public static int RoundNumber { get; private set; }
        /// <summary>
        /// The <see cref="Faction"/> which the player controls during combat.
        /// </summary>
        public static Faction PlayerFaction;
        /// <summary>
        /// Executes an entire <see cref="CombatScenario"/>, playing out rounds until its <see cref="CombatScenario.WinCondition">win condition</see> is met.
        /// </summary>
        /// <param name="scene">The scene to execute.</param>
        public static void DoScene(CombatScenario scene)
        {
            scene.Load();
            CurrentScene = scene;
            RoundNumber = 0;
            SceneStatus status;
            while((status = CurrentScene.CheckWinCondition) is not SceneStatus.Ongoing)
            {
                DoRound();
                RoundNumber++;
            }
            Debug.Log($"The scene {scene.Name} concluded with the result {status} after {RoundNumber} rounds.");
        }
        /// <summary>
        /// Performs one round, which consists of one turn per <see cref="Side"/> present in the scene.
        /// </summary>
        public static void DoRound()
        {
            Debug.Log($"Doing round {RoundNumber}...");
            DoTurn(CurrentScene.StartingSide);
            DoTurn(CurrentScene.StartingSide.Opposite());
        }
        /// <summary>
        /// Performs one <see cref="Side"/>'s turn, consisting of the set of turns of all <see cref="Character"/>s on that side.
        /// </summary>
        /// <param name="side">The <see cref="Side"/> whose <see cref="Character"/>s' turns will be executed.</param>
        public static void DoTurn(Side side)
        {
            Debug.Log($"\tDoing the {side} side's turn...");
            foreach (Character character in CurrentScene.CharactersOn(side))
            {
                character.DoTurn();
            }
        }
        /// <summary>
        /// Begins the <see cref="GameManager"/>'s execution of the scenes described in <see cref="Data.scenes"/>.
        /// </summary>
        void Start()
        {
            SceneManager.LoadSceneAsync("MainMenu");
            // foreach (CombatScenario scene in Data.Scenes) DoScene(scene);
        }
        public static void LoadMainMenu() => SceneManager.LoadSceneAsync("MainMenu");
        public static void LoadCombatScene() => SceneManager.LoadSceneAsync("Combat");
    }
}
