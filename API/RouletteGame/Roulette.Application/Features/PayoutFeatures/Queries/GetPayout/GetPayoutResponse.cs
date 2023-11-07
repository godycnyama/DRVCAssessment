namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
public sealed record GetPayoutResponse
{
    public int PayoutID { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public int AccountID { get; set; }
    public int SessionID { get; set; }
    public int BetID { get; set; }
}