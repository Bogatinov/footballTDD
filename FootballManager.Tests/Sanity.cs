using Xunit;

namespace FootballManager.Tests
{
    public class Sanity
    {
        [Fact(DisplayName = "Sanity check")]
        public void Check()
        {
            Assert.Equal(true, true);
        }
    }
}