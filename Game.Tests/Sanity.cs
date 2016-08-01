using Xunit;

namespace Game.Tests
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