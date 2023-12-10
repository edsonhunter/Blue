using Controller.Navigation;
using Controller.Player;
using UnityEngine;

namespace Controller.General
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField]
        private PlayerController PlayerController { get; set; }
        
        [field: SerializeField]
        private TileController TileController { get; set; }

        private void Awake()
        {
            PlayerController.Setup();
            TileController.Setup(Move);
        }

        private void Move(Vector2 moveTo)
        {
            PlayerController.Move(moveTo);
        }
    }
}