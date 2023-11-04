using MediatR;

namespace Roulette.Application.Features.SpinFeatures.DeleteSpin;

public sealed record DeleteSpinRequest(int Id) : IRequest<DeleteSpinResponse>;
