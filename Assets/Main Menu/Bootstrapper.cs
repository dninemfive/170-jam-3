using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamazonBrine
{
    public class Bootstrapper : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Init();
        }
    }
}
