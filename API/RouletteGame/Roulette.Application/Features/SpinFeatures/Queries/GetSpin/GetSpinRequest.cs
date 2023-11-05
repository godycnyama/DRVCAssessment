using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;

public sealed record GetSpinRequest(int Id) : IRequest<GetSpinResponse>;
