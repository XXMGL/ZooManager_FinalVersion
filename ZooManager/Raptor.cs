using System;

namespace ZooManager
{
    /// <summary>
    /// This class represents raptors, use the Iattacker interface.
    /// raptor: will attack mouse and cats, can move 2 steps when detect a prey
    /// </summary>
    public class Raptor : Bird
    {
        public Raptor(string name)
        {
            HomePlanet = "Earth";
            isHunt = false;
            isfly = false;
            emoji = "🦅";
            species = "Raptor";
            this.name = name;
            reactionTime = 1;
        }

        /// <summary>
        /// Activate all behaviours of raptor.
        /// </summary>
        /// <returns>void</returns>
        public override void Activate()
        {
            
            isHunt = false;
            isfly = false;
            base.Activate();
            Console.WriteLine("I am a Raptor. I'll eat cats and mouse.");
            string target1 = "cat";
            string target2 = "mouse";
            Hunt(target1);                    
            Hunt(target2);                    
            Console.WriteLine("Raptor is flying");
            Fly(target1);
            Fly(target2);
        }

        /// <summary>
        /// Checking four direction( in one step) and attack if cat/mouse is detected
        /// </summary>
        /// <returns>void</returns>
       /* public void Hunt()
        {

            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.up);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.down);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.left);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.right);
                isHunt = true;
            }
            
        }*/
        /// <summary>
        /// Checking four direction( in two step) and attack if cat/mouse is detected
        /// </summary>
        /// <returns>void</returns>
        /*public void Fly()
        {

            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.up);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.down);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.left);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.right);
            }
        }*/
    }
}

