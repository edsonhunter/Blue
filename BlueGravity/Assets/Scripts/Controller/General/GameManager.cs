using System;
using System.Collections.Generic;
using Controller.Navigation;
using Controller.Player;
using Domain.Interface;
using Service;
using Service.Interface;
using UnityEngine;

namespace Controller.General
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField]
        private PlayerController PlayerController { get; set; }
        
        [field: SerializeField]
        private BoardController BoardController { get; set; }

        private IGameService GameService { get; set; }

        private void Awake()
        {
            GameService = new GameService();
            
            BoardController.Setup(TileClicked);
        }

        private void Start()
        {
            BoardController.CreateMap(GameService.GenerateMap());
            PlayerController.Setup(GameService.GeneratePlayer());
        }

        private void TileClicked(ITile destTile)
        {
            var path = BoardController.CreatePath(PlayerController.Player.CurrentTile, destTile);
            PlayerController.Move(path, destTile); 
        }
    }
}