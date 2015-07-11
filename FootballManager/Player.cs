using System;

namespace FootballManager
{
    public class Player
    {
        public Player(string name)
        {
            Id = new Random().Next(1, 1000);
            Name = name;
            TeamId = 0;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TeamId { get; set; }
    }
}