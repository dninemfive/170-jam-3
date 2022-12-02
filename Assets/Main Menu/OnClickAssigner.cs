using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace JamazonBrine
{
    public class OnClickAssigner : MonoBehaviour
    {
        [SerializeField]
        private AssignableMethod MethodToAssign;
        private static Dictionary<AssignableMethod, UnityAction> AssignableMethods = new()
        {
            { AssignableMethod.GoToCombat, GameManager.GoToCombatScene },
            { AssignableMethod.GoToMainMenu, GameManager.GoToMainMenu },
            { AssignableMethod.FinishTurn, RoundManager.BeginNextTurn },
        };
        // Start is called before the first frame update
        void Start() => gameObject.AddButtonListener(AssignableMethods[MethodToAssign]);
    }
    public enum AssignableMethod { GoToCombat, GoToMainMenu, FinishTurn }
}
