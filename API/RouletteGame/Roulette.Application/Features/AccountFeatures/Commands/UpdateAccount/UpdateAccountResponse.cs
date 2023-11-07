namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
public sealed record UpdateAccountResponse
{
    public int AccountID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
}
