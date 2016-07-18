using Poker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Logic
{
    public class CardParser
    {
        public IEnumerable<Card> Parse(string[] cardInputs)
        {
            IEnumerable<Card> cards =
                from cardInput in cardInputs
                select new Card()
                {
                    Value = cardInput[0].FromSingleInput(),
                    Suit = (Suit)Enum.Parse(typeof(Suit), cardInput[1].ToString())
                };
            return cards;
        }
    }
}
