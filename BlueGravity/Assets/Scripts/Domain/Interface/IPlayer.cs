using UnityEngine;

namespace Domain.Interface
{
    public interface IPlayer
    {
        Vector2 Position { get; }
        bool Moving { get; }

        bool Move(Vector2 newPosition);
    }
}