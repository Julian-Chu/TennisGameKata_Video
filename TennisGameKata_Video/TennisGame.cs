using System;
using System.Collections.Generic;

namespace TennisGameKata_Video
{
    public class TennisGame
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;
        private int _firstPlayerScoreTimes;
        private int _secondPlayerScoreTimes;

        private Dictionary<int, string> scoreLookup = new Dictionary<int, string>()
            {
                {0,"Love" },
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public string Score()
        {
            return IsScoreDifferent()
                ? (IsReadyForWin() ? AdvStateScore() : NormalScore())
                : (IsDeuce() ? Deuce() : SameScore());
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private string AdvPlayerName()
        {
            var advPlayerName = _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayerName
                : _secondPlayerName;
            return advPlayerName;
        }

        private string AdvStateScore()
        {
            return AdvPlayerName() + (IsAdv() ? " Adv" : " Win");
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1;
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private bool IsReadyForWin()
        {
            return _firstPlayerScoreTimes > 3 || _secondPlayerScoreTimes > 3;
        }

        private bool IsScoreDifferent()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        private string NormalScore()
        {
            return scoreLookup[_firstPlayerScoreTimes] + " " + scoreLookup[_secondPlayerScoreTimes];
        }

        private string SameScore()
        {
            return scoreLookup[_firstPlayerScoreTimes] + " All";
        }
    }
}