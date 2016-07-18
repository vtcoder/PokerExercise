using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Domain.Entities;

namespace Poker.Domain.Logic.Tests
{
    [TestClass]
    public class ScoreCalculatorTests
    {
        [TestMethod]
        public void CalculateScoreTest_HighCard()
        {
            string[] cardInputs = new string[] { "3C", "4S", "JS", "KH", "AC" };
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score score = scoreCalculator.CalculateScore(cardInputs);
            Assert.AreEqual<Score>(Score.HighCard, score);
        }

        [TestMethod]
        public void CalculateScoreTest_OnePair()
        {
            string[] cardInputs = new string[] { "3C", "4S", "3S", "KH", "AC" };
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score score = scoreCalculator.CalculateScore(cardInputs);
            Assert.AreEqual<Score>(Score.OnePair, score);
        }

        [TestMethod]
        public void CalculateScoreTest_TwoPair()
        {
            string[] cardInputs = new string[] { "3C", "4S", "3S", "4H", "AC" };
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score score = scoreCalculator.CalculateScore(cardInputs);
            Assert.AreEqual<Score>(Score.TwoPair, score);
        }

        [TestMethod]
        public void CalculateScoreTest_ThreeOfAKind()
        {
            string[] cardInputs = new string[] { "3C", "3H", "3S", "4H", "AC" };
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            Score score = scoreCalculator.CalculateScore(cardInputs);
            Assert.AreEqual<Score>(Score.ThreeOfAKind, score);
        }
    }
}
