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
            Moving = false;
        }
        
        public Player(Vector2 position) : this()
        {
            Position = position;
        }
        
        public bool Move(Vector2 moveTo)
        {
            if (Moving)
                return false;

            Position = moveTo;
            return true;
        }
    }
}