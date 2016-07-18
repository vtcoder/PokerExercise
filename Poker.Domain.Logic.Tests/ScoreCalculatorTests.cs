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
    }
}
