using Domain.Interface;

namespace Domain.Player
{
    public class Player : IPlayer
    {
        public ITile CurrentTile { get; private set; }
        public bool Moving { get; }

        private Player()
        {
            Moving = false;
        }
        
        public Player(ITile currentTile) : this()
        {
            CurrentTile = currentTile;
        }
        
        public bool Move(ITile moveToTile)
        {
            if (Moving)
                return false;

            CurrentTile = moveToTile;
            return true;
        }
    }
}