using System;

namespace FootballManager
{
    public class TransferContract
    {
        private readonly Team _newTeam;
        private readonly Team _oldTeam;

        public TransferContract(Team oldTeam, Team newTeam)
        {
            Id = new Random().Next(1, 1000);
            _oldTeam = oldTeam;
            _newTeam = newTeam;
        }

        public int Id { get; private set; }

        public int Transfer(Player player)
        {
            var success = _oldTeam.RemovePlayer(player);
            if (success)
            {
                _newTeam.SignContract(player);
                return Id;
            }

            return 0;
        }
    }
}