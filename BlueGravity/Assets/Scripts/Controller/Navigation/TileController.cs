using System;
using Domain.Interface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller.Navigation
{
    public class TileController : MonoBehaviour, IPointerClickHandler
    {
        private ITile Tile { get; set; }
        private Action<ITile> OnClick { get; set; }

        public void Setup(Action<ITile> onTileClicked, ITile tile)
        {
            Tile = tile;
            OnClick = onTileClicked;
            transform.position = Tile.Position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke(Tile);
        }
    }
}
