using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Interface;
using UnityEngine;

namespace Controller.Player
{
    public class PlayerController : MonoBehaviour
    {
        internal IPlayer Player { get; set; }
        
        public void Setup(IPlayer player)
        {
            Player = player;
            transform.position = Player.CurrentTile.Position;
        }

        public void Move(IList<ITile> path, ITile destTile)
        {
            StartCoroutine(MovePlayer(path, destTile));
        }

        IEnumerator MovePlayer(IList<ITile> path, ITile destTile)
        {
            Player.Move(destTile);
            foreach (var newPos in path)
            {
                transform.position = newPos.Position;
                yield return new WaitForSeconds(0.5f);    
            }
        }
    }
}
