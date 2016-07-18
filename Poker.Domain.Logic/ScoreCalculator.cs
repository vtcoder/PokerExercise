﻿using Poker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Logic
{
    public class ScoreCalculator
    {
        private Dictionary<Score, Func<IEnumerable<Card>, bool>> _scores;

        public ScoreCalculator()
            : base()
        {
            _scores = new Dictionary<Score, Func<IEnumerable<Card>, bool>>();            
            _scores.Add(Score.TwoPair, cards => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2);
            _scores.Add(Score.OnePair, cards => cards.GroupBy(c => c.Value).Any(g => g.Count() == 2));
            _scores.Add(Score.HighCard, cards => true);
        }

        public Score CalculateScore(string[] cardInputs)
        {
            IEnumerable<Card> cards =
                from cardInput in cardInputs
                select new Card()
                {
                    Value = cardInput[0].FromSingleInput(),
                    Suit = (Suit)Enum.Parse(typeof(Suit), cardInput[1].ToString())
                };

            Score score = _scores.First(entry => entry.Value(cards)).Key;
            return score;
        }
    }
}
