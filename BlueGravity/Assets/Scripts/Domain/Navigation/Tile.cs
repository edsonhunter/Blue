using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Interface;
using UnityEngine;

namespace Domain.Navigation
{
    public class Tile : ITile
    {
        public Vector2 Position { get; private set; }
        public IList<ITile> Neighbors { get; private set; } 
        
        private Tile()
        {
            Position = Vector2.zero;
            Neighbors = new Collection<ITile>();
        }
        
        public Tile(Vector2 position) : this()
        {
            Position = position;
        }

        public void AddNeighbor(ITile neighbor)
        {
            Neighbors.Add(neighbor);
        }
    }
}