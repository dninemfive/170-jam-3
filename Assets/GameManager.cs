using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JamazonBrine 
{
    public class GameManager : MonoBehaviour
    {
        public static Scene CurrentScene;
        public static int RoundNumber { get; private set; } = 1;
        public static Faction PlayerFaction;
        public static void DoScene(Scene scene)
        {
            CurrentScene = scene;
            RoundNumber = 1;
            Side? winner = null;
            while((winner = CurrentScene.CheckWinCondition) is not null)
            {
                DoRound();
            }
            Debug.Log($"The {winner} side won after {RoundNumber} rounds.");
        }
        public static void DoRound()
        {
            Debug.Log($"Doing round {RoundNumber}...");
            DoTurn(CurrentScene.StartingSide);
            DoTurn(CurrentScene.StartingSide.Opposite());
        }
        public static void DoTurn(Side side)
        {
            // announce that {side} is going
            Debug.Log($"\tDoing the {side} side's turn...");
            foreach (Character character in CurrentScene.CharactersOn(side))
            {
                character.DoTurn();
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
