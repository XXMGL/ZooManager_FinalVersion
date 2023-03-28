using System;

namespace ZooManager
{
    /// <summary>
    /// This class represents animals.
    /// </summary>

    public class Animal : Creature,IPredator, IPrey
    {
      
        
      
            public bool Flee(string target)
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return true;
            }
            return false;
        }
 
        public void Hunt(string target)
        {
            if (isHunt == true) return;
            if (Behaviour.Seek(location.x, location.y, Direction.up, target) == 1)
            {
                Console.WriteLine("I find "+ target);
                Behaviour.Attack(this, Direction.up);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.down);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.left);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.right);
                isHunt = true;
            }
        }
        
    }

   
}
