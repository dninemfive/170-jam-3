using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamazonBrine
{
    /// <summary>
    /// A side a player can be on in gameplay, either left or right.
    /// </summary>
    public enum Side { Left, Right }
    /// <summary>
    /// The faction a <see cref="Character"/> is on. If this matches the <see cref="GameManager.PlayerFaction">player's faction</see>, the character is player-controlled.
    /// </summary>
    public enum Faction { Good, Bad }
    /// <summary>
    /// The result of a scene, either <c>Ongoing</c> or the scene's final outcome.
    /// </summary>
    public enum SceneStatus { Ongoing, LeftWon, RightWon, NeitherWon, BothWon }
    public enum VerticalPosition { Top, Bottom }
}
