using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    public static class Utilities
    {
        public static Side Opposite(this Side side) => side switch
        {
            Side.Left => Side.Right,
            Side.Right => Side.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(side))
        };
    }
    public enum Side { Left, Right }
    public enum Faction { Good, Bad }
}
