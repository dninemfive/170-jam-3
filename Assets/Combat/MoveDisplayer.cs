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
            RectTransform rtf = GetComponent<RectTransform>();
            Debug.Log($"Top left corner: {rtf.TopLeftCorner()}");
            float offset = MovePrefab.GetComponent<RectTransform>().rect.height, totalOffset = 0;
            float width = rtf.rect.width;
            Debug.Log($"offset is {offset}, width is {width}, anchored position = {rtf.anchoredPosition}");
            foreach(Move m in moves)
            {
                PlaceMove(m, rtf, totalOffset);
                totalOffset += offset;
            }
        }
        public void ClearCurrentMoves()
        {
            Debug.Log($"Clearing {CurrentMoves.Count} existing moves from the move displayer...");
            foreach (GameObject go in CurrentMoves) Destroy(go);
            CurrentMoves.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="parentRtf"></param>
        /// <param name="totalOffset"></param>
        /// <remarks>Referenced <see href="https://answers.unity.com/questions/1007886/how-to-set-the-new-unity-ui-rect-transform-anchor.html">this</see>.</remarks>
        public void PlaceMove(Move m, RectTransform parentRtf, float totalOffset)
        {
            Debug.Log($"Placing move {m.Name}...");
            GameObject mo = m.Instantiate(MovePrefab);
            CurrentMoves.Add(mo);
            RectTransform rtf = mo.GetComponent<RectTransform>();
            rtf.anchoredPosition = parentRtf.anchoredPosition;
            rtf.anchorMin = Vector2.right;
            rtf.anchorMax = Vector2.up;
            rtf.pivot = new(0, 0);
            rtf.transform.SetParent(parentRtf);
            Debug.Log($"Placed {m.Name} at {rtf.position}");
        }
    }
}
