using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;

public sealed record DepositAccountRequest(int AccountID, decimal Amount) : IRequest<DepositAccountResponse>;
