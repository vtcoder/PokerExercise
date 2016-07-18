using Poker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Logic
{
    public class ScoreCalculator
    {
        public Score CalculateScore(string[] cardInput)
        {
            return Score.HighCard;
        }
    }
}
