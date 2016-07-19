using System;

namespace Poker.Domain.Entities
{
    public enum Suit
    {
        Diamond = 0,
        Heart = 1,
        Club = 2,
        Spade = 3
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public enum Score
    {
        LowAceStraight = -1,
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfAKind = 7,
        StraightFlush = 8
    }

    public static class EnumExtensions
    {
        public static Value ToCardValue(this char input)
        {
            if (input == 'A')
                return Value.Ace;
            else if (input == 'K')
                return Value.King;
            else if (input == 'Q')
                return Value.Queen;
            else if (input == 'J')
                return Value.Jack;
            else
                return  (Value)Convert.ToInt32(input.ToString());
        }

        public static Suit ToCardSuit(this char input)
        {
            if (input == 'D')
                return Suit.Diamond;
            else if (input == 'H')
                return Suit.Heart;
            else if (input == 'C')
                return Suit.Club;
            else if (input == 'S')
                return Suit.Spade;
            else
                throw new InvalidOperationException();
        }
    }
}
