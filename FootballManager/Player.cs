using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private PlayerPosition _currentPosition { get; set; }
        public IList<PlayerPosition> PreferredPositions { get; set; }

        public CoachManager Manager { get; set; }

        public PlayerPosition Position { get { return _currentPosition; } }

        private Player()
        {
            PreferredPositions = new List<PlayerPosition> { PlayerPosition.GK };
        }

        public Player(PlayerPosition position) : this()
        {
            this.ChangePosition(position);
        }

        public void ChangePosition(PlayerPosition newPosition)
        {
            if (PreferredPositions.Contains(_currentPosition))
            {
                _currentPosition = newPosition;

            }
            else
            {
                throw new Exception("Cant change position if player does not like it");
            }
        }
    }

    public class CoachManager
    {
        public string Name { get; set; }

        public IList<Player> myPlayers { get; set; }

        public CoachManager()
        {
            myPlayers = new List<Player>();
        }
        public void PredefinePostions(Player player, List<PlayerPosition> positions)
        {
            myPlayers[0].PreferredPositions = positions;
        }

        public void ChangePlayerPosition(Player player, PlayerPosition newPosition)
        {
            foreach (Player p in myPlayers.Where(t => t.Name == player.Name))
            {
                p.ChangePosition(newPosition);
            }
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