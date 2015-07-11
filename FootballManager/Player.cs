using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int TeamId { get; set; }

        public Player(string name)
        {
            Id = new Random().Next(1, 1000);
            Name = name;
            TeamId = 0;
        }
    }
}
