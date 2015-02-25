using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class Manager
    {
        public void ChangePlayerPosition(Player player, PlayerPosition position)
        {
            if (player.IsPositionAllowed(position))
            {
                player.CurrentPosition = position;
            }
            else
            {
                throw new Exception("Can't change not learned position");
            }
        }

        public void TeachPlayerNewPosition(Player player, PlayerPosition position)
        {
            player.LearnPosition(position);
        }
    }
}
