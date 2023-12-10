using System;
using System.Collections.Generic;
using Domain.Interface;
using UnityEngine;

namespace Controller.Navigation
{
    public class BoardController : MonoBehaviour
    {
        [field: SerializeField]
        private TileController TilePrefab { get; set; }
        
        private IList<TileController> TileControllers { get; set; }
        private Action<Vector2> OnTileClicked { get; set; }

        public void Setup(Action<Vector2> onTileClicked)
        {
            TileControllers = new List<TileController>();
            OnTileClicked = onTileClicked;
        }
        
        public void CreateMap(IList<ITile> map)
        {
            foreach (var tile in map)
            {
                var controller = Instantiate(TilePrefab, transform);
                controller.Setup(Move, tile);
                TileControllers.Add(controller);
            }
        }
        
        private void Move(Vector2 moveTo)
        {
            OnTileClicked.Invoke(moveTo);
        }
    }
}