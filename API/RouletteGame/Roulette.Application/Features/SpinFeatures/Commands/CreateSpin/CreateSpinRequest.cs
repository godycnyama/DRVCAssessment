using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;

public sealed record CreateSpinRequest(int Number,int AccountID, int SessionID) : IRequest<CreateSpinResponse>;
