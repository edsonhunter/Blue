using Domain.Interface;
using UnityEngine;

namespace Controller.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayer Player { get; set; }
        
        public void Setup()
        {
            Player = new Domain.Player.Player(new Vector2(0, 1));
            transform.position = Player.Position;
        }

        public void Move(Vector2 moveTo)
        {
            Player.Move(moveTo);
            transform.position = Player.Position;
        }
    }
}
