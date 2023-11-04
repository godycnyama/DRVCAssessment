namespace Roulette.Application.Features.BetFeatures.GetBet;
public sealed record GetBetResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Number { get; set; }
}