using Poker.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Poker.Domain.Logic
{
    /// <summary>
    /// Responsible for parsing card input from a file.
    /// </summary>
    public class CardParser
    {
        public CardParser()
            : base()
        {
        }

        public IEnumerable<Card> Parse(string[] cardInputs)
        {
            IEnumerable<Card> cards =
                from cardInput in cardInputs
                select new Card()
                {
                    Value = cardInput[0].ToCardValue(),
                    Suit = cardInput[1].ToCardSuit()
                };
            return cards;
        }

        public string[] LoadCardInputFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                string[] cardInputs = line.Split(new char[] { ' ' });
                return cardInputs;
            }
        }

        public IEnumerable<Card> LoadCardsFromFile(string filePath)
        {
            string[] cardInputs = LoadCardInputFromFile(filePath);
            IEnumerable<Card> cards = Parse(cardInputs);
            return cards;
        }
    }
}
