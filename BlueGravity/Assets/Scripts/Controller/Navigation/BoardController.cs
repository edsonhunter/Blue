using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Interface;
using UnityEngine;

namespace Controller.Navigation
{
    public class BoardController : MonoBehaviour
    {
        [field: SerializeField] private TileController TilePrefab { get; set; }

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
                controller.Setup(TileClicked, tile);
                TileControllers.Add(controller);
            }
        }

        private void TileClicked(Vector2 moveTo)
        {
            OnTileClicked.Invoke(moveTo);
        }

        public IList<Vector2> CreatePath(Vector2 origin, Vector2 destination)
        {
            var path = new List<Vector2>();
            var closed = new List<Vector2>();
            Debug.Log($"{origin} : {destination}");
            path.Add(origin);
            int safeCounter = 0;
            while (safeCounter < 999)
            {
                safeCounter++;
                var current = path.Last();
                Debug.Log("counter:" + safeCounter +"current: "+current);
                if (closed.Contains(current))
                {
                    continue;
                }

                if (current == destination)
                {
                    return path;
                }

                closed.Add(current);
                if (destination.x > current.x)
                {
                    current += Vector2.right;
                }
                else if (destination.x < current.x)
                {
                    current += Vector2.left;
                }
                else if (destination.y > current.y)
                {
                    current += Vector2.up;
                }
                else if (destination.y < current.y)
                {
                    current += Vector2.down;
                }

                Debug.Log(current);
                path.Add(current);
            }

            return new List<Vector2>();
        }
    }
}