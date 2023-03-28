using System;
using System.Linq;
namespace ZooManager
{
    public static class Behaviour
    {
        /// <summary>
        /// Checking all zones and activate detected animals
        /// </summary>
        /// <param name="r">The reaction time of animals. This will decide which animal move first.</param>
        /// <returns>void</returns>
        static public void ActivateAnimals()
        {
            for (var r = 1; r < 11; r++) // reaction times from 1 to 10
            {             
                Game.animalZones
    .SelectMany(zoneRow => zoneRow) // flatten 2D array into 1D
    .Where(zone => zone.occupant != null && zone.occupant.reactionTime == r)
    .ToList() // convert to list so we can use ForEach
    .ForEach(zone => zone.occupant.Activate());
            }
            for(var r = 1; r < 11; r++)
            {
                Game.animalZones
   .SelectMany(zoneRow => zoneRow) // flatten 2D array into 1D
   .Where(zone => zone.occupant != null && zone.occupant.isActivated == true)
   .ToList() // convert to list so we can use ForEach
   .ForEach(zone => zone.occupant.isActivated=false);//Set all activated creature to be able to be activated next time
            }
        }
        /// <summary>
        /// Checking all zones on one direction and get the distance if there is something detected
        /// </summary>
        /// <param name="x">The animal location on x axis</param>        
        /// <param name="y">The animal location on y axis</param>
        /// <param name="d">The detection direction</param>
        /// <param name="target">The method will return a value if it detects the target</param>
        /// <returns>the distance to the target</returns>
        static public int Seek(int x, int y, Direction d, string target)
        {
            int distance = 0;
            if ((y == 0 && d == Direction.up) 
                || (y == Game.numCellsY - 1 && d == Direction.down) 
                || (x == 0 && d == Direction.left) 
                || (x == Game.numCellsX - 1 && d == Direction.right)) return 0;
            while (y >= 0 && x >= 0 && y <= Game.numCellsY - 1 && x <= Game.numCellsX - 1)
            {
                
                switch (d)
                {
                    case Direction.up:
                        if (y == 0) return 0;
                        y--;
                        break;
                    case Direction.down:
                        if (y == Game.numCellsY - 1) return 0;
                        y++;
                        break;
                    case Direction.left:
                        if (x == 0) return 0;
                        x--;
                        break;
                    case Direction.right:
                        if (x == Game.numCellsX - 1) return 0;
                        x++;
                        break;
                }
                distance++;
                if (Game.animalZones[y][x].occupant != null)
                {
                    if (Game.animalZones[y][x].occupant.species == target)
                    {
                        return distance;
                    }
                }                                   
            }                                                                
            if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return 0;
            if (Game.animalZones[y][x].occupant == null) return 0;
            return 0;
        }
        /// <summary>
        /// Checking all zones on one direction and get the distance if there is something detected, this is specially for aliens
        /// </summary>
        /// <param name="x">The animal location on x axis</param>        
        /// <param name="y">The animal location on y axis</param>
        /// <param name="d">The detection direction</param>
        /// <param name="target">The method will return a value if it detects the target</param>
        /// <returns>the distance to the target</returns>
        static public int AlienSeek(int x, int y, Direction d, string target)
        {
            int distance = 0;
            if ((y == 0 && d == Direction.up)
                || (y == Game.numCellsY - 1 && d == Direction.down)
                || (x == 0 && d == Direction.left)
                || (x == Game.numCellsX - 1 && d == Direction.right)) return 0;
            while (y >= 0 && x >= 0 && y <= Game.numCellsY - 1 && x <= Game.numCellsX - 1)
            {

                switch (d)
                {
                    case Direction.up:
                        if (y == 0) return 0;
                        y--;
                        break;
                    case Direction.down:
                        if (y == Game.numCellsY - 1) return 0;
                        y++;
                        break;
                    case Direction.left:
                        if (x == 0) return 0;
                        x--;
                        break;
                    case Direction.right:
                        if (x == Game.numCellsX - 1) return 0;
                        x++;
                        break;
                }
                distance++;
                if (Game.animalZones[y][x].occupant != null)
                {
                    if (Game.animalZones[y][x].occupant.HomePlanet == target)
                    {
                        return distance;
                    }
                }
            }
            if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return 0;
            if (Game.animalZones[y][x].occupant == null) return 0;
            return 0;
        }

        /// <summary>
        /// Make a attack on one direction and move the animal to target area
        /// </summary>
        /// <param name="attacker">the animal name which will make an attack</param>        
        /// <param name="d">The attack direction</param>
        /// <returns>void</returns>
        static public void Attack(Creature attacker, Direction d)
        {
            Console.WriteLine($"{attacker.name} is attacking {d.ToString()}");
            int x = attacker.location.x;
            int y = attacker.location.y;

            switch (d)
            {
                case Direction.up:
                    Game.animalZones[y - 1][x].occupant = attacker;
                    break;
                case Direction.down:
                    Game.animalZones[y + 1][x].occupant = attacker;
                    break;
                case Direction.left:
                    Game.animalZones[y][x - 1].occupant = attacker;
                    break;
                case Direction.right:
                    Game.animalZones[y][x + 1].occupant = attacker;
                    break;
            }
            Game.animalZones[y][x].occupant = null;
        }


        /// <summary>
        /// Run from attacker,take one step backward in the direction where attack come from.
        /// </summary>
        /// <param name="runner">The animal name which will retreat</param>        
        /// <param name="d">The direction where attack come from</param>
        /// <returns>return a boolean if retreat successfully</returns>

        static public bool Retreat(Creature runner, Direction d)
        {
            Console.WriteLine($"{runner.name} is retreating {d.ToString()}");
            int x = runner.location.x;
            int y = runner.location.y;

            switch (d)
            {
                case Direction.up:
                    if (y > 0 && Game.animalZones[y - 1][x].occupant == null)
                    {
                        Game.animalZones[y - 1][x].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true; // retreat was successful
                    }
                    return false; // retreat was not successful
                case Direction.down:
                    if (y < Game.numCellsY - 1 && Game.animalZones[y + 1][x].occupant == null)
                    {
                        Game.animalZones[y + 1][x].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (x > 0 && Game.animalZones[y][x - 1].occupant == null)
                    {
                        Game.animalZones[y][x - 1].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (x < Game.numCellsX - 1 && Game.animalZones[y][x + 1].occupant == null)
                    {
                        Game.animalZones[y][x + 1].occupant = runner;
                        Game.animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
            }
            return false; // fallback
        }
        /// <summary>
        /// Run from attacker,take multiple steps backward in the direction where attack come from.
        /// </summary>
        /// <param name="runner">The animal name which will retreat</param>        
        /// <param name="d">The direction where attack come from</param>
        /// <param name="distance">How many steps it can move</param>
        /// <returns>return a integer of how many steps runner takes</returns>
        static public int Move(Animal runner, Direction d, int distance)
        {
            int movestep = 0;
            int x = runner.location.x;
            int y = runner.location.y;
            for (int i = 0; i < distance; i++)
            {
                switch (d)
                {
                    case Direction.up:
                        if (y > 0 && Game.animalZones[y - 1][x].occupant == null)
                        {
                            y = y - 1;
                            Game.animalZones[y ][x].occupant = runner;
                            Game.animalZones[y+1][x].occupant = null;
                            movestep++;
                        }
                        break;
                    case Direction.down:
                        if (y < Game.numCellsY - 1 && Game.animalZones[y + 1][x].occupant == null)
                        {
                            y = y + 1;
                            Game.animalZones[y][x].occupant = runner;
                            Game.animalZones[y-1][x].occupant = null;
                            movestep++;
                        }
                        break;
                    case Direction.left:
                        if (x > 0 && Game.animalZones[y][x - 1].occupant == null)
                        {
                            x = x - 1;
                            Game.animalZones[y][x].occupant = runner;
                            Game.animalZones[y][x+1].occupant = null;
                            movestep++;
                        }
                        break;
                    case Direction.right:
                        if (x < Game.numCellsX - 1 && Game.animalZones[y][x + 1].occupant == null)
                        {
                            x = x + 1;
                            Game.animalZones[y][x].occupant = runner;
                            Game.animalZones[y][x-1].occupant = null;
                            movestep++;
                        }
                        break;
                }               
            }
            return movestep;
        }

        /// <summary>
        /// Make a attack multiple steps away.
        /// </summary>
        /// <param name="attacker">The animal name which will make an attack</param>        
        /// <param name="d">The direction where attack aim to</param>
        /// <param name="distance">How many steps it can move</param>
        /// <returns>void</returns>
        static public void fly(Animal attacker, Direction d)
        {
            
            int x = attacker.location.x;
            int y = attacker.location.y;

            switch (d)
            {
                case Direction.up:
                    Game.animalZones[y - 2][x].occupant = attacker;
                    break;
                case Direction.down:
                    Game.animalZones[y + 2][x].occupant = attacker;
                    break;
                case Direction.left:
                    Game.animalZones[y][x - 2].occupant = attacker;
                    break;
                case Direction.right:
                    Game.animalZones[y][x + 2].occupant = attacker;
                    break;
            }
            Game.animalZones[y][x].occupant = null;
        }
      
    }
    public interface IPredator
    {
        void Hunt(string target);
        /*void Fly();*/

    }
    public interface IPrey
    {
        bool Flee(string target);
        /*void MoveRandom();*/
    }
}
