using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class TransferContract
    {
        public int Id { get; private set; }
        private Team _oldTeam;
        private Team _newTeam;
        
        public TransferContract(Team oldTeam, Team newTeam)
        {
            Id = new Random().Next(1, 1000);
            _oldTeam = oldTeam;
            _newTeam = newTeam;
        }

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
