namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
public class UpdateAccountResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
}
