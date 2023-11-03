using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Number { get; set; }
    }
}
