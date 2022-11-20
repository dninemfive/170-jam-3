using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    public record CharacterLocation
    {
        public Side Side;
        public int Order;
        public CharacterLocation(Side side, int order)
        {
            Side = side;
            Order = order;
        }
    }
}
