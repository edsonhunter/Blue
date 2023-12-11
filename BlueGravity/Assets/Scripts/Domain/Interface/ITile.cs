using System.Collections.Generic;
using UnityEngine;

namespace Domain.Interface
{
    public interface ITile
    {
        Vector2 Position { get; }
        IList<ITile> Neighbors { get; }

        void AddNeighbor(ITile neighbor);
    }
}