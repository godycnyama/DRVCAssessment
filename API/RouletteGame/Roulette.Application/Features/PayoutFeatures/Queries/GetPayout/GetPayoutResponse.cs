namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
public sealed record GetPayoutResponse
{
    public int Id { get; set; }
    public int Amount { get; set; }
}