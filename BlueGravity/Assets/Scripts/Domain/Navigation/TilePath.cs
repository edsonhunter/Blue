using System.Collections.Generic;
using System.Linq;
using Domain.Interface;

namespace Domain.Navigation
{
    public class TilePath : ITilePath
    {
        public IList<ITile> Tiles { get; }
        public ITile LastTile { get; private set; }
        public TilePath()
        {
            Tiles = new List<ITile>();
        }
        
        public TilePath(ITilePath tilePath)
        {
            Tiles = new List<ITile>(tilePath.Tiles.ToList());
        }

        public void AddTile(ITile tile)
        {
            Tiles.Add(tile);
            LastTile = tile;
        }
    }
}