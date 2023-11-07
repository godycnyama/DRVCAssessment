namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
public sealed record GetAccountsResponse
{
    public int AccountID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
}