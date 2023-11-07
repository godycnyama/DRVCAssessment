using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities;
public class Session
{
    [Key]
    public int SessionID { get; set; }
    [Required]
    public decimal WinningBonus { get; set; }
    [Required]
    [MaxLength(4)]
    public string Currency { get; set; }
}
