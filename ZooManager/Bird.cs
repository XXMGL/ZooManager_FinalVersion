using System;

namespace ZooManager
{
    /// <summary>
    /// This class represents the bird including chick, raptor.
    /// </summary>

    public class Bird : Animal
    {
        public bool isfly = false;
        public void Fly(string target)
        {
            if (isfly == true) return;
            if (Behaviour.Seek(location.x, location.y, Direction.up, target) == 2 )
            {
                Behaviour.fly(this, Direction.up);
                isfly = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, target) == 2 )
            {
                Behaviour.fly(this, Direction.down);
                isfly = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, target) == 2 )
            {
                Behaviour.fly(this, Direction.left);
                isfly = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, target) == 2 )
            {
                Behaviour.fly(this, Direction.right);
                isfly = true;
            }
        }
    }
}

