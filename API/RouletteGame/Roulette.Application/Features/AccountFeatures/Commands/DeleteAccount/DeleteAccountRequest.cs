using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;

public sealed record DeleteAccountRequest(int AccountID) : IRequest<DeleteAccountResponse>;
