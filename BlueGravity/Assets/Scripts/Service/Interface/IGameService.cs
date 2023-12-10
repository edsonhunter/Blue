using System.Collections.Generic;
using Domain.Interface;

namespace Service.Interface
{
    public interface IGameService
    {
        IList<ITile> GenerateMap();
    }
}