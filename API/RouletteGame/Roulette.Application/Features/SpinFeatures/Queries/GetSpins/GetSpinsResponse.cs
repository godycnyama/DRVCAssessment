namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpins;
public sealed record GetSpinsResponse
{
    public int SpinID { get; set; }
    public int Number { get; set; }
    public int AccountID { get; set; }
    public int SessionID { get; set; }
}