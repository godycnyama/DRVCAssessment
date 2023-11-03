using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Entities
{
    public class Payout
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
}
