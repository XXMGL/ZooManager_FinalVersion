using System;

namespace ZooManager
{
    /// <summary>
    /// This class represents mouse, use the Irunner and Iattacker interface.
    /// mouse: run from raptor. will attack mouse and chick. can only move one step when running or attacking.
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string name)
        {
            HomePlanet = "Earth";
            isHunt = false;
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        /// <summary>
        /// Activate all behaviours of cat.
        /// </summary>
        /// <returns>void</returns>
        public override void Activate()
        {
            
            isHunt = false;
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            string target1 = "mouse";
            string target2 = "Raptor";
            if(Flee(target2))return;
            Hunt(target1);
        }

        /// <summary>
        /// Checking four direction( in one step) and attack if chick/mouse is detected
        /// </summary>
        /// <returns>void</returns>
        
        
        /*public void Hunt()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.up);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.down);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.left);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.right);
            }
        }*/
       /* /// <summary>
        /// For avoiding errors
        /// </summary>
        /// <returns>void</returns>
        public void Fly()
        {

        }*/
        /*/// <summary>
        /// For avoiding errors
        /// </summary>
        /// <returns>void</returns>
        public void MoveRandom()
        {

        }*/
        /// <summary>
        /// Checking four direction( in one step) and retreat if raptor is detected
        /// </summary>
        /// <returns>the boolean represents whether the mouse retreat successfully</returns>
        /*public bool Flee()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return true;
            }
            return false;
        }*/
    }
}

