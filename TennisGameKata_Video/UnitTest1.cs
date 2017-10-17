using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGameKata_Video
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void love_all()
        {
            TennisGame tennisGame = new TennisGame();
            string score = tennisGame.Score();
            Assert.AreEqual("Love All",score);
        }
    }
}
