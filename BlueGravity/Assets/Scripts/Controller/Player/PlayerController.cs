using System.Collections;
using System.Collections.Generic;
using Domain.Interface;
using UnityEngine;

namespace Controller.Player
{
    public class PlayerController : MonoBehaviour
    {
        internal IPlayer Player { get; set; }
        
        public void Setup()
        {
            Player = new Domain.Player.Player(new Vector2(0, 1));
            transform.position = Player.Position;
        }

        public void Move(IList<Vector2> path)
        {
            StartCoroutine(MovePlayer(path));
        }

        IEnumerator MovePlayer(IList<Vector2> path)
        {
            foreach (var newPos in path)
            {
                transform.position = newPos;
                yield return new WaitForSeconds(0.5f);    
            }

            Player.Move(transform.position);
        }
    }
}
