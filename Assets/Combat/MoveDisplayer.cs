using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    public class MoveDisplayer : MonoBehaviour
    {
        [SerializeField]
        public GameObject MovePrefab;
        public void LoadMoves(Character character)
        {
            Debug.Log($"ActionDisplayer.LoadMoves({character.Name})");
            List<Move> moves = character.Archetype.Moves;
            Rect rect = GetComponent<RectTransform>().rect;
            float offset = MovePrefab.GetComponent<RectTransform>().rect.height, totalOffset = 0;
            float width = rect.width;
            Debug.Log($"offset is {offset}, width is {width}");
            foreach(Move m in moves)
            {
                Debug.Log($"Adding move {m.Name}...");
                GameObject mo = m.Instantiate(MovePrefab);
                mo.transform.SetParent(transform);
                Vector3 tf = new(transform.position.x - width / 2, totalOffset);
                totalOffset += offset;
                Debug.Log($"Placed {m.Name} at {tf}");
                mo.transform.position = tf;
            }
        }
    }
}
