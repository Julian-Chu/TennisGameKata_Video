using System;
using System.Collections.Generic;

namespace TennisGameKata_Video
{
    public class TennisGame
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;
        private int _firstPlayerScoreTimes;

        private Dictionary<int, string> scoreLookup = new Dictionary<int, string>()
            {
                {0,"Love" },
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" },
            };

        private int _secondPlayerScoreTimes;

        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public string Score()
        {
            return IsScoreDifferent()
                ? (IsReadyForWin() ? AdvStateScore() : NormalScore())
                : (IsDeuce() ? Deuce() : SameScore());
        }

        private bool IsScoreDifferent()
        {
            return _firstPlayerScoreTimes != _secondPlayerScoreTimes;
        }

        private string AdvStateScore()
        {
            return AdvPlayerName() + (IsAdv() ? " Adv" : " Win");
        }

        private bool IsReadyForWin()
        {
            return _firstPlayerScoreTimes > 3 || _secondPlayerScoreTimes > 3;
        }

        private string NormalScore()
        {
            return scoreLookup[_firstPlayerScoreTimes] + " " + scoreLookup[_secondPlayerScoreTimes];
        }

        private string SameScore()
        {
            return scoreLookup[_firstPlayerScoreTimes] + " All";
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return _firstPlayerScoreTimes >= 3;
        }

        private bool IsAdv()
        {
            return Math.Abs(_firstPlayerScoreTimes - _secondPlayerScoreTimes) == 1;
        }

        private string AdvPlayerName()
        {
            var advPlayerName = _firstPlayerScoreTimes > _secondPlayerScoreTimes
                ? _firstPlayerName
                : _secondPlayerName;
            return advPlayerName;
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScoreTimes++;
        }
    }
}