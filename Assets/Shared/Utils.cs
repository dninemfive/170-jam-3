using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }    
}
