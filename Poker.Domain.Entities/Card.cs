using System;

namespace Poker.Domain.Entities
{
    /// <summary>
    /// Represents a card from a standard 52-card deck.
    /// </summary>
    public class Card
    {
        public Card()
            : base()
        {
        }

        public Suit Suit { get; set; }
        public Value Value { get; set; }
    }
}
