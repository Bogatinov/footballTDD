using System;
using System.Collections.Generic;

namespace Game
{
    public class Team
    {
        public Team(string name)
        {
            Id = new Random().Next(1, 1000);
            Name = name;
            _players = new List<Player>();
        }

        private int Id { get; set; }
        public string Name { get; private set; }
        private ICollection<Player> _players { get; set; }

        public bool SignContract(Player player)
        {
            if (player.TeamId != 0)
                return false;
            player.TeamId = Id;
            _players.Add(player);
            return true;
        }

        public void RemovePlayer(Player player)
        {
            if(_players.Count == 0)
                throw new Exception("There are no players");
            var result = _players.Remove(player);
            if (result)
                player.TeamId = 0;
        }
    }
}