using System;
using System.Collections.Generic;
using Controller.Navigation;
using Controller.Player;
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
            
            PlayerController.Setup();
            BoardController.Setup(TileClicked);
        }

        private void Start()
        {
            BoardController.CreateMap(GameService.GenerateMap());
        }

        private void TileClicked(Vector2 tilePos)
        {
            Move(BoardController.CreatePath(PlayerController.Player.Position, tilePos));
            
        }

        private void Move(IList<Vector2> path)
        {
            PlayerController.Move(path);
        }
    }
}