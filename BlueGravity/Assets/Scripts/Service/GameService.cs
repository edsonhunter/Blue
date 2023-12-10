using System.Collections.Generic;
using Domain.Interface;
using Domain.Navigation;
using Service.Interface;
using UnityEngine;

namespace Service
{
    public class GameService : IGameService
    {
        private const int MAP_WIDTH = 10;
        private const int MAP_HEIGHT = 20;
        public IList<ITile> GenerateMap()
        {
            IList<ITile> map = new List<ITile>();
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    map.Add(new Tile(new Vector2(x,y), false));
                }
            }
            return map;
        }
    }
}