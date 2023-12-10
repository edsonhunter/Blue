using System;
using Domain.Interface;
using Domain.Navigation;
using UnityEngine;

namespace Controller.Navigation
{
    public class TileController : MonoBehaviour
    {
        private ITile Tile { get; set; }
        private Action<Vector2> OnClick { get; set; }

        public void Setup(Action<Vector2> onTileClicked)
        {
            Tile = new Tile(new Vector2(2,2), false);
            transform.position = Tile.Position;
            
            OnClick = onTileClicked;
        }

        private void OnMouseDown()
        {
            OnClick.Invoke(Tile.Position);
        }
    }
}
