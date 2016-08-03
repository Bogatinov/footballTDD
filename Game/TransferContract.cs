using System;

namespace Game
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

        private int Id { get; }

        public int Transfer(Player player)
        {
            _oldTeam.RemovePlayer(player);
            _newTeam.SignContract(player);
            return Id;
        }
    }
}