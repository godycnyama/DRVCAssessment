using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;

public sealed record UpdateSpinRequest(int SpinID, int Number, int AccountID, int SessionID) : IRequest<UpdateSpinResponse>;
