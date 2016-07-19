using Poker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain.Logic
{
    /// <summary>
    /// Responsible for calculating the score of poker hands.
    /// </summary>
    public class ScoreCalculator
    {
        private Dictionary<Score, Func<IEnumerable<Card>, bool>> _scores;

        public ScoreCalculator()
            : base()
        {
            _scores = new Dictionary<Score, Func<IEnumerable<Card>, bool>>();
            _scores.Add(Score.StraightFlush, cards => IsStraightFlush(cards));
            _scores.Add(Score.FourOfAKind, cards => IsFourOfAKind(cards));
            _scores.Add(Score.FullHouse, cards => IsFullHouse(cards));
            _scores.Add(Score.Flush, cards => IsFlush(cards));
            _scores.Add(Score.Straight, cards => IsStraight(cards));
            _scores.Add(Score.LowAceStraight, cards => IsLowAceStraight(cards));
            _scores.Add(Score.ThreeOfAKind, cards => IsThreeOfAKind(cards));
            _scores.Add(Score.TwoPair, cards => IsTwoPair(cards));
            _scores.Add(Score.OnePair, cards => IsOnePair(cards));
            _scores.Add(Score.HighCard, cards => true);
        }

        public Score CalculateScore(IEnumerable<Card> cards)
        {
            Score score = _scores.First(entry => entry.Value(cards)).Key;
            return score;
        }

        private bool IsStraightFlush(IEnumerable<Card> cards)
        {
            //We have a straight flush if we have a straight, and a flush.
            bool isStraightFlush = IsStraight(cards) && IsFlush(cards);

            return isStraightFlush;
        }

        private bool IsFourOfAKind(IEnumerable<Card> cards)
        {
            //Group the cards by their value.
            var groupedByValue = cards.GroupBy(c => c.Value);

            //If any of the groups have an item count of 4, then we have four-of-a-kind.
            bool isFourOfAKind = groupedByValue.Any(g => g.Count() == 4);

            return isFourOfAKind;
        }

        private bool IsFullHouse(IEnumerable<Card> cards)
        {
            //We have a full house if we have one-pair, and three-of-a-kind.
            bool isFullHouse = IsOnePair(cards) && IsThreeOfAKind(cards);
            
            return isFullHouse;
        }

        private bool IsFlush(IEnumerable<Card> cards)
        {
            //Group the cards by their suit.
            var groupedBySuit = cards.GroupBy(c => c.Suit);

            //If there is only a single group for suit, then we have a flush.
            bool isFlush = groupedBySuit.Count() == 1;

            return isFlush;
        }

        private bool IsStraight(IEnumerable<Card> cards)
        {
            bool isStraight = false;

            //Make sure there are 5 unique card values.
            if (cards.Select(c => c.Value).Distinct().Count() == 5)
            {
                //Determine the min and max cards.
                var max = cards.Max(c => c.Value);
                var min = cards.Min(c => c.Value);

                //If the range is 4, then this is a straight.
                isStraight = max - min == 4;

                //If not a straight, check for an ace-low straight.
                if (!isStraight)
                    isStraight = IsLowAceStraight(cards);
            }

            return isStraight;
        }

        private bool IsLowAceStraight(IEnumerable<Card> cards)
        {
            bool isLowAceStraight = false;

            //Determine if the lowest card is a 2.
            if (cards.Min(c => c.Value) == Value.Two)
            {
                //Determine the max card, excluding aces.
                var excludeAces = cards.Where(c => c.Value != Value.Ace).Distinct();
                var maxCard = excludeAces.Max(c => c.Value);

                //If the range is 3, then this is a 2-to-5 straight (excluding aces).
                isLowAceStraight = maxCard - Value.Two == 3;
            }

            return isLowAceStraight;
        }

        private bool IsThreeOfAKind(IEnumerable<Card> cards)
        {
            //Group the cards by their value.
            var groupedByValue = cards.GroupBy(c => c.Value);

            //If any of the groups have an item count of 3, then we have three-of-a-kind.
            bool isThreeOfAKind = groupedByValue.Any(g => g.Count() == 3);

            return isThreeOfAKind;
        }

        private bool IsTwoPair(IEnumerable<Card> cards)
        {
            //Group the cards by their value.
            var groupedByValue = cards.GroupBy(c => c.Value);

            //If there are 2 groups that have an item count of 2, then we have two-pair.
            bool isTwoPair = groupedByValue.Count(g => g.Count() == 2) == 2;

            return isTwoPair;
        }

        private bool IsOnePair(IEnumerable<Card> cards)
        {
            //Group the cards by their value.
            var groupedByValue = cards.GroupBy(c => c.Value);

            //If any of the groups have an item count of 2, then we have one-pair.
            bool isOnePair = groupedByValue.Any(g => g.Count() == 2);

            return isOnePair;
        }
    }
}
