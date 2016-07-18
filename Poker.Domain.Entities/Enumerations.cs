using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Entities
{
    public enum Suit
    {
        D = 0,
        H = 1,
        C = 2,
        S = 3
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
        public static Value FromSingleInput(this char input)
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
                return (Value)input;
        }
    }
}
