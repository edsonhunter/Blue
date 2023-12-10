using UnityEngine;

namespace Domain.Interface
{
    public interface ITile
    {
        Vector2 Position { get; }
        bool Ocuppied { get; }
    }
}