using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Domain.Entities;

namespace Poker.Domain.Logic.Tests
{
    [TestClass]
    public class ScoreCalculatorTests
    {
        private void AssertHandScore(Score expectedScore, params string[] cardInputs)
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score actualScore = scoreCalculator.CalculateScore(cardInputs);
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
        public void CalculateScoreTest_Flush()
        {
            AssertHandScore(Score.Flush, "3C", "4C", "JC", "QC", "AC");
        }

        [TestMethod]
        public void CalculateScoreTest_FullHouse()
        {
            AssertHandScore(Score.FullHouse, "3C", "3D", "4C", "4S", "4H");
        }
    }
}
