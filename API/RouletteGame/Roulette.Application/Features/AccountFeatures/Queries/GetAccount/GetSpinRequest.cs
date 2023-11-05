using MediatR;

namespace Roulette.Application.Features.SpinFeatures.GetSpin;

public sealed record GetSpinRequest(int Id) : IRequest<GetSpinResponse>;
