using System;
using System.Collections.Generic;
using Xunit;

namespace FootballManager.Tests
{
    public class PlayerTests
    {
        [Fact(DisplayName = "Can change position")]
        public void CanChangePosition()
        {
            var player = new Player(PlayerPosition.GK)
            {
                Name = "Aleksandar"
            };
            var playerPositions = new List<PlayerPosition>()
            {
                PlayerPosition.RB,
                PlayerPosition.GK
            };
            player.PreferredPositions = playerPositions;

            player.ChangePosition(PlayerPosition.RB);

            Assert.True(player.Position == PlayerPosition.RB);
        } 
    }
}
