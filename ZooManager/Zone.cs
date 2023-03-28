using System;
namespace ZooManager
{
    /// <summary>
    /// This class represents the zones.
    /// </summary>
    public class Zone
    {
        private Creature _occupant = null;
        public Creature occupant
        {
            get { return _occupant; }
            set {
                _occupant = value;
                if (_occupant != null) {
                    _occupant.location = location;
                }
            }
        }

        public Point location;
        /// <summary>
        /// this is method for setting emojis on zones
        /// </summary>
        /// <returns>the string of emoji</returns>
        public string emoji
        {
            get
            {
                if (occupant == null) return "";
                return occupant.emoji;
            }
        }
        /// <summary>
        /// this is method for getting reaction time of the zone
        /// </summary>
        /// <returns>the string of the reaction time</returns>
        public string rtLabel
        {
            get
            {
                if (occupant == null) return "";
                return occupant.reactionTime.ToString();
            }
        }

        public Zone(int x, int y, Creature animal)
        {
            location.x = x;
            location.y = y;

            occupant = animal;
        }
    }
}
