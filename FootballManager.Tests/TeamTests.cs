using System;
using Xunit;

namespace FootballManager.Tests
{
    public class TeamTestMotherObject
    {
    }

    public class TeamTests
    {
        private readonly Team barcelona;
        private readonly Player messi;

        public TeamTests()
        {
            messi = new Player("Messi");
            barcelona = new Team("Barcelona");
        }

        [Fact(DisplayName = "Can sign a free agent player")]
        public void CanSignFreeAgentPlayer()
        {
            var successfulContract = barcelona.SignContract(messi);

            Assert.True(successfulContract);
        }

        [Fact(DisplayName = "Can not sign a signed player to team")]
        public void CanNotSignAlreadySignedPlayer()
        {
            barcelona.SignContract(messi);
            var arsenal = new Team("Arsenal");

            var successfulContract = arsenal.SignContract(messi);

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
            barcelona.SignContract(messi);
            var arsenal = new Team("Arsenal");
            var contract = new TransferContract(barcelona, arsenal);

            //Act = WHEN
            var contractId = contract.Transfer(messi);

            //Assert = THEN
            Assert.NotEqual(0, contractId);
        }

        [Fact(DisplayName = "Can not transfer free agent in transfer season")]
        public void CanNotTransferFreeAgent()
        {
            var arsenal = new Team("Arsenal");
            var contract = new TransferContract(null, arsenal);

            Assert.Throws<NullReferenceException>(() => contract.Transfer(messi));
        }

        [Fact(DisplayName = "Can not transfer free agent in transfer season with falsified contract")]
        public void CanNotTransferFreeAgentWithFalsifiedContract()
        {
            var vardar = new Team("Vardar");
            var contract = new TransferContract(vardar, barcelona);

            var contractId = contract.Transfer(messi);

            Assert.Equal(0, contractId);
        }
    }
}