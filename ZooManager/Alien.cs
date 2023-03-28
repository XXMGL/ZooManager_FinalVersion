using System;
namespace ZooManager
{
    public class Alien : Creature,IPredator
    {

        public Alien(string name)
        {
            HomePlanet = "Mars";
            emoji = "👾";
            species = "Alien";
            this.name = name;
            reactionTime = 1; // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {

            isHunt = false;
            base.Activate();
            Console.WriteLine("Bi Bi Bi Bi Bi Du~");
            string target1 = "Earth";
            Hunt(target1);
        }

        public void Hunt(string target)
        {
            if (isHunt == true) return;
            if (Behaviour.AlienSeek(location.x, location.y, Direction.up, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.up);
                isHunt = true;
            }
            else if (Behaviour.AlienSeek(location.x, location.y, Direction.down, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.down);
                isHunt = true;
            }
            else if (Behaviour.AlienSeek(location.x, location.y, Direction.left, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.left);
                isHunt = true;
            }
            else if (Behaviour.AlienSeek(location.x, location.y, Direction.right, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.right);
                isHunt = true;
            }
        }
    }


    }
