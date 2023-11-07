using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities
{
    public class Payout
    {
        [Key]
        public int PayoutID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(4)]
        public string Currency { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required]
        public int SessionID { get; set; }
        [Required]
        public int BetID { get; set; }
    }
}
