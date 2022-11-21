using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    /// <summary>
    /// Stores a character's location in a scene, which is determined by which <see cref="Side"/> it's on and its order in the turns for its side.
    /// </summary>
    public record CharacterLocation
    {
        /// <summary>
        /// The <see cref="JamazonBrine.Side"/> this character is on, either <c>Left</c> or <c>Right</c>. 
        /// </summary>
        public Side Side;
        /// <summary>
        /// The order in each turn the character takes. Lower numbers go first.
        /// </summary>
        public int Order;
        public CharacterLocation(Side side, int order)
        {
            Side = side;
            Order = order;
        }
    }
}
