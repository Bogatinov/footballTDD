using System;
using Xunit;

namespace Game.Tests
{
    public class TeamTests
    {
        private Player _player;
        private Team _team;

        public TeamTests()
        {
            _player = new Player("player1");
            _team = new Team("team1");
        }

        [Fact(DisplayName = "Can not remove player from team without players")]
        public void CanNotRemovePlayerFromTeamWithoutPlayers()
        {
            //Act/Assert
            Assert.Throws<Exception>(() => _team.RemovePlayer(_player));
        }

        [Fact(DisplayName = "Make player free agent")]
        public void MakePlayerFreeAgent()
        {
            _team.SignContract(_player);

            //Act
            _team.RemovePlayer(_player);

            //Assert
            Assert.Equal(0, _player.TeamId);
        }


        [Fact(DisplayName = "Can sign a free agent player")]
        public void CanSignFreeAgentPlayer()
        {
            var successfulContract = _team.SignContract(_player);

            Assert.True(successfulContract);
        }

        [Theory(DisplayName = "Can not sign a signed player to team")]
        public void CanNotSignAlreadySignedPlayer()
        {
            _team.SignContract(_player);
            var arsenal = new Team("test1");

            var successfulContract = arsenal.SignContract(_player);

            Assert.False(successfulContract);
        }

        /* Feature: Transfer player to new team
         * Given team Arsenal and Barcelona
         * And player Messi signed by Barcelona
         * When transfer season and Arsenal buys Messi
         * Then Messi signed by Arsenal
         */

        [Fact(DisplayName = "Transfer player to new team in transfer season")]
        public void TransferPlayerToNewTeam()
        {
            //Arrange = GIVEN
            _team.SignContract(_player);
            var arsenal = new Team("team2");
            var contract = new TransferContract(_team, arsenal);

            //Act = WHEN
            var contractId = contract.Transfer(_player);

            //Assert = THEN
            Assert.NotEqual(0, contractId);
        }

        [Fact(DisplayName = "Can not transfer free agent in transfer season")]
        public void CanNotTransferFreeAgent()
        {
            var arsenal = new Team("team2");
            var contract = new TransferContract(null, arsenal);

            Assert.Throws<NullReferenceException>(() => contract.Transfer(_player));
        }

        [Fact(DisplayName = "Can not transfer free agent in transfer season with falsified contract")]
        public void CanNotTransferFreeAgentWithFalsifiedContract()
        {
            var vardar = new Team("Vardar");
            var contract = new TransferContract(_team, vardar);

            Assert.Throws<Exception>(() => contract.Transfer(_player)); 
        }
    }
}