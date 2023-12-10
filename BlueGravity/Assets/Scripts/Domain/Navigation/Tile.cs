using Domain.Interface;
using UnityEngine;

namespace Domain.Navigation
{
    public class Tile : ITile
    {
        public Vector2 Position { get; }
        public bool Ocuppied { get; }
        
        private Tile()
        {
            Position = Vector2.zero;
        }
        
        public Tile(Vector2 position, bool ocuppied) : this()
        {
            Position = position;
            Ocuppied = ocuppied;
        }
    }
}