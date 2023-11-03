using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Domain.Entities
{
    public class Spin
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
