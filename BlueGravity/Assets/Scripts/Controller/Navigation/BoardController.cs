using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interface;
using Domain.Navigation;
using UnityEngine;

namespace Controller.Navigation
{
    public class BoardController : MonoBehaviour
    {
        [field: SerializeField] private TileController TilePrefab { get; set; }

        private IList<IList<ITile>> Map { get; set; }
        private Action<ITile> OnTileClicked { get; set; }

        public void Setup(Action<ITile> onTileClicked)
        {
            OnTileClicked = onTileClicked;
        }

        public void CreateMap(IList<IList<ITile>> map)
        {
            Map = map;
            
            foreach (var row in map)
            {
                foreach (var tile in row)
                {
                    var controller = Instantiate(TilePrefab, transform);
                    controller.Setup(TileClicked, tile);    
                }
            }
        }

        private void TileClicked(ITile moveToTile)
        {
            OnTileClicked.Invoke(moveToTile);
        }

        public IList<ITile> CreatePath(ITile origin, ITile destination)
        {
            var open = new List<ITilePath>();
            var closed = new List<ITile>();
            
            var originPath = new TilePath();
            originPath.AddTile(origin);
            open.Add(originPath);

            while (open.Count > 0)
            {
                var current = open.First();
                open.Remove(current);
                
                if (current.LastTile == destination)
                {
                    return current.Tiles;
                }
                
                if (closed.Contains(current.LastTile))
                {
                    continue;
                }

                closed.Add(current.LastTile);

                foreach (var neighbor in current.LastTile.Neighbors)
                {
                    var newPath = new TilePath(current);
                    newPath.AddTile(neighbor);
                    open.Add(newPath);
                }
            }

            return new List<ITile>();
        }
    }
}