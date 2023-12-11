using System.Collections.Generic;

namespace Domain.Interface
{
    public interface ITilePath
    {
        IList<ITile> Tiles { get; }
        ITile LastTile { get; }

        void AddTile(ITile tile);
    }
}