using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JamazonBrine
{
    public class OnClickAssigner_Combat : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            try
            {
                gameObject.GetComponent<Button>().onClick.AddListener(GameManager.GoToCombatScene);
            } catch
            {
                Debug.Log(gameObject.name);
            }
        }
    }
}
