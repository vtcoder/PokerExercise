using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Domain.Entities;
using System.Collections.Generic;

namespace Poker.Domain.Logic.Tests
{
    /// <summary>
    /// Contains unit tests for the ScoreCalculator class.
    /// </summary>
    [TestClass]
    public class ScoreCalculatorTests
    {
        public ScoreCalculatorTests()
            : base()
        {
        }

        private void AssertHandScore(Score expectedScore, params string[] cardInputs)
        {
            CardParser parser = new CardParser();
            IEnumerable<Card> cards = parser.Parse(cardInputs);

            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score actualScore = scoreCalculator.CalculateScore(cards);

            Assert.AreEqual<Score>(expectedScore, actualScore);
        }

        [TestMethod]
        public void CalculateScoreTest_HighCard()
        {
            AssertHandScore(Score.HighCard, "3C", "4S", "JS", "KH", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_OnePair()
        {
            AssertHandScore(Score.OnePair, "3C", "4S", "3S", "KH", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_TwoPair()
        {
            AssertHandScore(Score.TwoPair, "3C", "4S", "3S", "4H", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_ThreeOfAKind()
        {
            AssertHandScore(Score.ThreeOfAKind, "3C", "3H", "3S", "4H", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_Straight()
        {
            AssertHandScore(Score.Straight, "3C", "4H", "5S", "6H", "7C");
        }

        [TestMethod]
        public void CalculateScoreTest_Straight_RangeCheck()
        {
            AssertHandScore(Score.OnePair, "3C", "3H", "4S", "6H", "7C");
        }

        [TestMethod]
        public void CalculateScoreTest_Straight_StartingWithAce()
        {
            AssertHandScore(Score.Straight, "AC", "2D", "3C", "4H", "5S");
        }

        [TestMethod]
        public void CalculateScoreTest_Flush()
        {
            AssertHandScore(Score.Flush, "3C", "4C", "JC", "QC", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_FullHouse()
        {
            AssertHandScore(Score.FullHouse, "3C", "3D", "4C", "4S", "4H");
        }

        [TestMethod]
        public void CalculateScoreTest_FourOfAKind()
        {
            AssertHandScore(Score.FourOfAKind, "3C", "3H", "3S", "3D", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_StraightFlush()
        {
            AssertHandScore(Score.StraightFlush, "3C", "4C", "5C", "6C", "7C");
        }

        [TestMethod]
        public void CalculateScoreTest_StraightFlush_StartingWithAce()
        {
            AssertHandScore(Score.StraightFlush, "3C", "4C", "AC", "2C", "5C");
        }
    }
}
