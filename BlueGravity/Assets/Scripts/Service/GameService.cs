using System.Collections.Generic;
using Domain.Interface;
using Domain.Navigation;
using Domain.Player;
using Service.Interface;
using UnityEngine;

namespace Service
{
    public class GameService : IGameService
    {
        private const int MAP_WIDTH = 10;
        private const int MAP_HEIGHT = 20;
        
        private IList<IList<ITile>> Map { get; set; }
        public  IList<IList<ITile>> GenerateMap()
        {
            Map = new List<IList<ITile>>();
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                IList<ITile> row = new List<ITile>();
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    row.Add(new Tile(new Vector2(x,y)));
                }
                Map.Add(row);
            }

            for (int x = 0; x < MAP_WIDTH; x++)
            {
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    var tile = Map[x][y];
                    
                    //up
                    if (tile.Position.y > 0) {
                        tile.AddNeighbor(Map[x] [y-1]);
                    }

                    //down
                    if (tile.Position.y < MAP_HEIGHT - 1) {
                        tile.AddNeighbor(Map[x] [y+1]);
                    }
		
                    //left
                    if (tile.Position.x > 0) {
                        tile.AddNeighbor(Map[x-1] [y]);
                    }
                    //right
                    if (tile.Position.x < MAP_WIDTH - 1) {
                        tile.AddNeighbor(Map[x+1] [y]);
                    }
                }
            }
            
            return Map;
        }

        public IPlayer GeneratePlayer()
        {
            return new Player(Map[0][0]);
        }
    }
}