namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;
public sealed record GetPayoutsResponse
{
    public int Id { get; set; }
    public int Amount { get; set; }
}