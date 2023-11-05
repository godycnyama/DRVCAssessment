using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;

public sealed record DeleteSpinRequest(int Id) : IRequest<DeleteSpinResponse>;
