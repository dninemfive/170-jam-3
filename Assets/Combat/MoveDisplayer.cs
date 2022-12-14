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
        private GameObject MovePrefab;
        private readonly List<GameObject> CurrentMoves = new();
        private RectTransform rtf = null;
        public RectTransform RectTransform
        {
            get
            {
                if (rtf is null) rtf = GetComponent<RectTransform>();
                return rtf;
            }
        }
        public void LoadMoves(Character character)
        {
            ClearCurrentMoves();
            List<Move> moves = character.Archetype.Moves;
            RectTransform rtf = GetComponent<RectTransform>();
            float offset = MovePrefab.GetComponent<RectTransform>().rect.height, totalOffset = 0;
            foreach(Move m in moves)
            {
                PlaceMove(m, rtf, totalOffset);
                totalOffset += offset;
            }
            // foreach (GameObject go in CurrentMoves) Debug.Log($"Move {go.name} is at {go.transform.position} / {go.GetComponent<RectTransform>().position}");
        }
        public void ClearCurrentMoves()
        {
            //Debug.Log($"Clearing {CurrentMoves.Count} existing moves from the move displayer...");
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
            //Debug.Log($"Placing move {m.Name}...");
            GameObject mo = m.Instantiate(MovePrefab);
            CurrentMoves.Add(mo);
            RectTransform rtf = mo.GetComponent<RectTransform>();
            rtf.transform.SetParent(parentRtf);
            //rtf.localScale = Vector3.one;
            rtf.transform.localPosition = LeftCornerLocalCoords.OffsetBy(-totalOffset);
        }
        public Vector2 LeftCornerLocalCoords
        {
            get
            {
                float x = -RectTransform.rect.width / 2;
                float y = RectTransform.rect.height;
                return new(x, y);
            }
        }
    }
}
