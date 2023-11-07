using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities
{
    public class Spin
    {
        [Key]
        public int SpinID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required]
        public int SessionID { get; set; }

    }
}
