using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamazonBrine
{
    /// <summary>
    /// Static class defining miscellaneous extensions and other utility functions.
    /// </summary>
    public static class Utilities
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
        /// <summary>
        /// Converts the specified <see cref="Texture2D"/> into a sprite, using the entire texture.
        /// </summary>
        /// <param name="tex">The <see cref="Texture2D"/> to make the sprite from.</param>
        /// <returns>A sprite using the entire texture specified.</returns>
        /// <remarks>Used <see href="https://answers.unity.com/questions/650552/convert-a-texture2d-to-sprite.html">this page</see> for reference.</remarks>
        public static Sprite ToSprite(this Texture2D tex) => Sprite.Create(tex, new(0, 0, tex.width, tex.height), new(0.5f, 0.5f));
    }    
}
