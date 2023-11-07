using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;

public sealed record DeleteSpinRequest(int SpinID) : IRequest<DeleteSpinResponse>;
