using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    public static class RoundManager
    {
        public static int RoundNumber { get; private set; }
        private static int characterIndex = 0;
        public static int CharacterIndex
        {
            get => characterIndex;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value >= CharacterOrder.Count) characterIndex = 0;
                else characterIndex = value;
            }
        }
        private static List<Character> CharacterOrder { get; set; }
        public static CombatScenario CurrentScenario => GameManager.CurrentScenario;
        public static Character CurrentCharacter => CharacterOrder[CharacterIndex];
        public static ScenarioStatus CurrentStatus = ScenarioStatus.Ongoing;
        public static void BeginScenario()
        {
            // zero so that it's 1 after the increment in BeginNextRound()
            RoundNumber = 0;
            CharacterOrder = CurrentScenario.CharacterOrder.ToList();
            BeginNextRound();
        }
        public static void BeginNextRound()
        {
            RoundNumber++;
            CharacterIndex = 0;
            if((CurrentStatus = CurrentScenario.CheckWinCondition) is not ScenarioStatus.Ongoing)
            {
                EndScenario();
                return;
            }
            BeginNextTurn();
        }
        public static void BeginNextTurn()
        {
            CurrentCharacter.DoTurn();
            if(CharacterIndex >= CharacterOrder.Count)
            {
                BeginNextRound();
            }
            else
            {
                CharacterIndex++;
            }
        }
        public static void EndScenario()
        {
            Debug.Log($"Completed scenario {CurrentScenario.Name} with status {CurrentStatus}");
        }
    }
}
