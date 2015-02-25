using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class Player
    {
        private readonly IList<PlayerPosition> _preferredPositions;
        public PlayerPosition CurrentPosition { get;set; }

        public Player()
        {
            _preferredPositions = new List<PlayerPosition>();
        }

        public void LearnPosition(PlayerPosition newPosition)
        {
            _preferredPositions.Add(newPosition);
        }

        public bool IsPositionAllowed(PlayerPosition position)
        {
            return _preferredPositions.Contains(position);
        }
    }

    public enum PlayerPosition
    {
        GK,
        SW,
        CB,
        LB,
        RB,
        RWB,
        LWB,
        DM,
        CM,
        AM,
        LW,
        RW,
        WF,
        CF
    }
}