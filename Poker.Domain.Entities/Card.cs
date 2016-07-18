using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Entities
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }
    }
}
