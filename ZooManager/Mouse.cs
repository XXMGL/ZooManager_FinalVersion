using System;
namespace ZooManager
{
    /// <summary>
    /// This class represents mouse, use the Irunner interface.
    /// mouse: run from cat and raptor. can move 2 steps when find a raptor
    /// </summary>
    public class Mouse : Animal
    {
        public Mouse(string name)
        {
            HomePlanet = "Earth";
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
        }

        /// <summary>
        /// Activate all behaviours of mouse.
        /// </summary>
        /// <returns>void</returns>
        public override void Activate()
        {
           
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            string target1 = "cat";
            Flee(target1);
            MoveRandom();
            
        }

        /// <summary>
        /// Checking four direction( in one step) and retreat if cat is detected
        /// </summary>
        /// <returns>the boolean represents whether the mouse retreat successfully</returns>
       /* public bool Flee()
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
        }
*/
        /// <summary>
        /// Checking four direction( in two steps ) and move two steps randomly if raptor is detected
        /// </summary>
        /// <returns>void</returns>
        public void MoveRandom()
        {
            int steps = 0;
            Random rnd = new Random();
            Direction randomDirection = (Direction)rnd.Next(Enum.GetNames(typeof(Direction)).Length);
            if (Behaviour.Seek(location.x, location.y, Direction.up, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
        }
    }
}

