using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JamazonBrine
{
    /// <summary>
    /// Static class defining miscellaneous extensions and other utility functions.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Returns the opposite <see cref="Side"/> from the one specified.
        /// </summary>
        /// <param name="side">The side whose opposite to find. <em>Must</em> be <c>Left</c> or <c>Right</c>.</param>
        /// <returns><c>Right</c> if <c>Left</c> is specified, or vice versa.</returns>
        /// <remarks>Throws an error if any other value is passed, e.g. by casting an int to a <see cref="Side"/>.</remarks>
        public static Side Opposite(this Side side) => side switch
        {
            Side.Left => Side.Right,
            Side.Right => Side.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(side))
        };
        public static void LoadScene(string sceneName) => SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        public static void AddButtonListener(this GameObject gameObject, UnityAction action)
        {
            try
            {
                gameObject.GetComponent<Button>().onClick.AddListener(action);
            }
            catch(Exception e)
            {
                Debug.Log($"Error adding action {action} to game object {gameObject.name}:\n{e}");
            }
        }
        public static GameObject Instantiate(this Character character, GameObject prefab)
        {
            GameObject characterObject = GameObject.Instantiate(prefab);
            characterObject.GetComponent<Image>().sprite = character.Texture.ToSprite();
            characterObject.transform.Find("Nameplate").GetComponent<TextMeshProUGUI>().text = character.Name;
            return characterObject;
        }
        public static GameObject Instantiate(this Move move, GameObject prefab)
        {
            GameObject actionObject = GameObject.Instantiate(prefab);
            actionObject.transform.Find("Nameplate").GetComponent<TextMeshProUGUI>().text = move.Name;
            return actionObject;
        }
        /// <summary>
        /// Converts the specified <see cref="Texture2D"/> into a sprite, using the entire texture.
        /// </summary>
        /// <param name="tex">The <see cref="Texture2D"/> to make the sprite from.</param>
        /// <returns>A sprite using the entire texture specified.</returns>
        /// <remarks>Used <see href="https://answers.unity.com/questions/650552/convert-a-texture2d-to-sprite.html">this page</see> for reference.</remarks>
        public static Sprite ToSprite(this Texture2D tex) => Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(0.5f, 0.5f));
        public static string CommaSeparatedList(this IEnumerable<string> strings) => strings.Aggregate((string a, string b) => $"{a}, {b}");
        public static float SideCoord(this RectTransform rtf, Side side) => side switch
        {
            Side.Left => rtf.gameObject.transform.position.x - rtf.rect.width / 2,
            Side.Right => rtf.gameObject.transform.position.x + rtf.rect.width / 2,
            _ => throw new ArgumentOutOfRangeException(nameof(side))
        };
        public static float VerticalCoord(this RectTransform rtf, VerticalPosition vp) => vp switch
        {
            VerticalPosition.Top => rtf.gameObject.transform.position.y + rtf.rect.height / 2,
            VerticalPosition.Bottom => rtf.gameObject.transform.position.y - rtf.rect.height / 2,
            _ => throw new ArgumentOutOfRangeException(nameof(vp))
        };
        public static Vector2 Corner(this RectTransform rtf, Side side, VerticalPosition vp) => new(rtf.SideCoord(side), rtf.VerticalCoord(vp));
        public static Vector2 TopLeftCorner(this RectTransform rtf) => rtf.Corner(Side.Left, VerticalPosition.Top);
        public static Vector2 OffsetBy(this Vector2 vec, float x = 0, float y = 0) => vec + new Vector2(x, y);
    }    
}
