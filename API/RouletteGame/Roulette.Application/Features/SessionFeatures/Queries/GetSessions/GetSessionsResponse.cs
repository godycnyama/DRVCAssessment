namespace Roulette.Application.Features.SessionFeatures.Queries.GetSessions;
public sealed record GetSessionsResponse
{
    public int SessionID { get; set; }
    public decimal WinningBonus { get; set; }
    public string Currency { get; set; }
}