using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JamazonBrine 
{
    /// <summary>
    /// The <see cref="MonoBehaviour"/> used to bootstrap the rest of the game logic. Contains the core code for gameplay.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The current <see cref="Scene"/> being played.
        /// </summary>
        public static Scene CurrentScene;
        /// <summary>
        /// The number of rounds which have elapsed, including the current round. Starts at 1.
        /// </summary>
        public static int RoundNumber { get; private set; } = 1;
        /// <summary>
        /// The <see cref="Faction"/> which the player controls during combat.
        /// </summary>
        public static Faction PlayerFaction;
        /// <summary>
        /// Executes an entire <see cref="Scene"/>, playing out rounds until its <see cref="Scene.WinCondition">win condition</see> is met.
        /// </summary>
        /// <param name="scene">The scene to execute.</param>
        public static void DoScene(Scene scene)
        {
            CurrentScene = scene;
            RoundNumber = 1;
            Side? winner;
            // Loops until there is a non-null winner of the scene.
            // Possible todo: support for an outcome other than winning?
            while((winner = CurrentScene.CheckWinCondition) is not null)
            {
                DoRound();
            }
            Debug.Log($"The {winner} side won after {RoundNumber} rounds.");
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
            foreach (Scene scene in Data.Scenes) DoScene(scene);
        }
    }
}
