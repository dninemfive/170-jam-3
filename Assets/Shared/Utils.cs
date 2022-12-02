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
        public static Vector2 OffsetBy(this Vector2 vec, float x = 0, float y = 0) => vec + new Vector2(x, y);
        public static System.Random Rng = new();
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            if (!enumerable.Any()) return default;
            return enumerable.ElementAt(Rng.Next(0, enumerable.Count() - 1));
        }
        public static IEnumerable<Side> AllSides
        {
            get
            {
                yield return Side.Left;
                yield return Side.Right;
            }
        }
    }    
}
