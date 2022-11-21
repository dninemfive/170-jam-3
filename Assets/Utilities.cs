using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }    
}
