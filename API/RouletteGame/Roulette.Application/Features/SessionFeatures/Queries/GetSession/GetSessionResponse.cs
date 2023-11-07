namespace Roulette.Application.Features.SessionFeatures.Queries.GetSession;
public sealed record GetSessionResponse
{
    public int SessionID { get; set; }
    public decimal WinningBonus { get; set; }
    public string Currency { get; set; }
}