namespace Roulette.Application.Features.BetFeatures.Queries.GetBets;
public sealed record GetBetsResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Number { get; set; }
}