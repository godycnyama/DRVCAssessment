using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public decimal Balance { get; set; } = 0;
        [Required]
        [MaxLength(4)]
        public string Currency { get; set; }
    }
}
