using System.ComponentModel.DataAnnotations;

namespace Roulette.Domain.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; } = 0;
    }
}
