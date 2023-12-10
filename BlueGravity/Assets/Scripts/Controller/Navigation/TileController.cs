using System;
using Domain.Interface;
using Domain.Navigation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller.Navigation
{
    public class TileController : MonoBehaviour, IPointerClickHandler
    {
        private ITile Tile { get; set; }
        private Action<Vector2> OnClick { get; set; }

        public void Setup(Action<Vector2> onTileClicked, ITile tile)
        {
            Tile = tile;
            OnClick = onTileClicked;
            transform.position = Tile.Position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke(Tile.Position);
        }
    }
}
