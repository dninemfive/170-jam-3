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
        private readonly List<GameObject> CurrentMoves = new();
        public void LoadMoves(Character character)
        {
            ClearCurrentMoves();
            Debug.Log($"ActionDisplayer.LoadMoves({character.Name})");
            List<Move> moves = character.Archetype.Moves;
            Rect rect = GetComponent<RectTransform>().rect;
            Debug.Log($"Top left corner: {rect.TopLeftCorner()}");
            float offset = MovePrefab.GetComponent<RectTransform>().rect.height, totalOffset = 0;
            float width = rect.width;
            Debug.Log($"offset is {offset}, width is {width}");
            foreach(Move m in moves)
            {
                PlaceMove(m, rect, totalOffset);
                totalOffset += offset;
            }
        }
        public void ClearCurrentMoves()
        {
            Debug.Log($"Clearing {CurrentMoves.Count} existing moves from the move displayer...");
            foreach (GameObject go in CurrentMoves) Destroy(go);
            CurrentMoves.Clear();
        }
        public void PlaceMove(Move m, Rect rect, float totalOffset)
        {
            Debug.Log($"Placing move {m.Name}...");
            GameObject mo = m.Instantiate(MovePrefab);
            CurrentMoves.Add(mo);
            mo.transform.SetParent(transform);
            Vector3 tf = rect.TopLeftCorner() - new Vector2(0, totalOffset);
            Debug.Log($"Placed {m.Name} at {tf}");
            mo.transform.position = tf;
        }
    }
}
