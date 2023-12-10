using Domain.Interface;
using UnityEngine;

namespace Domain.Player
{
    public class Player : IPlayer
    {
        public Vector2 Position { get; private set; }
        public bool Moving { get; }

        private Player()
        {
            Position = Vector2.zero;    
        }
        
        public Player(Vector2 position, bool moving)
        {
            Position = position;
            Moving = moving;
        }
        
        public bool Move(Vector2 newPosition)
        {
            if (Moving)
                return false;

            Position = newPosition;
            return true;
        }
    }
}