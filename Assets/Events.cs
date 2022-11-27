using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace JamazonBrine
{
    public static class Events
    {
        public static readonly Action<int> SelectUITestDropdown = delegate (int x)
        {
            if (x is 0) GameManager.Instance.SetUpCombat();
            if (x is 1) GameManager.Instance.SetUpDialog();
        };
    }
}
