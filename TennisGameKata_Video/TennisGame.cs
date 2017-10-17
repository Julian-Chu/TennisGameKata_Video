using System.Collections.Generic;

namespace TennisGameKata_Video
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> scoreLookup = new Dictionary<int, string>()
            {
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        public string Score()
        {
            if (_firstPlayerScoreTimes > 0)
            {
                return scoreLookup[_firstPlayerScoreTimes] + " Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }
    }
}