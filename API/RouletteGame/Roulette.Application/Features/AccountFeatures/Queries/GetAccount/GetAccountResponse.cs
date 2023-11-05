namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
public sealed record GetAccountResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
}