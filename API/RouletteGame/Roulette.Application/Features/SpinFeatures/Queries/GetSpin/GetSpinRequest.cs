using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;

public sealed record GetSpinRequest(int SpinID) : IRequest<GetSpinResponse>;
