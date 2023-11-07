namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
public sealed record GetSpinResponse
{
    public int SpinID { get; set; }
    public int Number { get; set; }
    public int AccountID { get; set; }
    public int SessionID { get; set; }
}