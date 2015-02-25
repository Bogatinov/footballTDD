using System;
using System.Collections.Generic;
using Xunit;

namespace FootballManager.Tests
{
    public class PlayerTests
    {

        [Fact(DisplayName = "Place player on preferred position")]
        public void CanPlacePlayerOnLearnedPosition()
        {
            //Arrange
            var player = new Player() { CurrentPosition = PlayerPosition.RB };
            var manager = new Manager();
            manager.TeachPlayerNewPosition(player, PlayerPosition.GK);

            //Act
            manager.ChangePlayerPosition(player, PlayerPosition.GK);

            //Assert
            Assert.Equal(PlayerPosition.GK, player.CurrentPosition);
        }

        [Fact(DisplayName = "Do not place player on unpreferred position")]
        public void CanNotPlacePlayerOnNotLearnedPosition()
        {
            var player = new Player() { CurrentPosition = PlayerPosition.RB };
            var manager = new Manager();
            Assert.ThrowsAny<Exception>(() => manager.ChangePlayerPosition(player, PlayerPosition.GK));
        }
    }
}
