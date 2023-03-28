using System;
namespace ZooManager
{
    /// <summary>
    /// This class represents chicks, use the Irunner interface.
    /// mouse: run from cat. can move only one step
    /// </summary>
    public class Chick : Bird 
    {
        public Chick(string name)
        {
            HomePlanet = "Earth";
            emoji = "🐥";
            species = "Chick";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(6, 10); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        /// <summary>
        /// Activate all behaviours of chick.
        /// </summary>
        /// <returns>void</returns>
        public override void Activate()
        {
         
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            string target = "cat";
            Flee(target);
        }

        /// <summary>
        /// Checking four direction( in one step) and retreat if cat is detected
        /// </summary>
        /// <returns>the boolean represents whether the mouse retreat successfully</returns>
        /*public bool Flee()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return true;
            }
            return false;
        }*/
      /*  /// <summary>
        /// For avoiding errors
        /// </summary>
        /// <returns>void</returns>
        public void MoveRandom()
        {

        }*/
    }
}

