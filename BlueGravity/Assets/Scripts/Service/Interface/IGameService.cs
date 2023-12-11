using System.Collections.Generic;
using Domain.Interface;

namespace Service.Interface
{
    public interface IGameService
    {
        IList<IList<ITile>> GenerateMap();
        IPlayer GeneratePlayer();
    }
}