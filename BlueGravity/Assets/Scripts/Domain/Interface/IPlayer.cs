using UnityEngine;

namespace Domain.Interface
{
    public interface IPlayer
    {
        ITile CurrentTile { get; }
        bool Moving { get; }
        

        bool Move(ITile moveToTile);
    }
}