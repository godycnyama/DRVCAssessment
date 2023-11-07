using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities
{
    public class Bet
    {
        [Key]
        public int BetID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required]
        public int SessionID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(4)]
        public string Currency { get; set; }
    }
}
