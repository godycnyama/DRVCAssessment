namespace Roulette.Application.Features.BetFeatures.Queries.GetBets;
public sealed record GetBetsResponse
{
    public int BetID { get; set; }
    public int AccountID { get; set; }
    public int SessionID { get; set; }
    public int Number { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}