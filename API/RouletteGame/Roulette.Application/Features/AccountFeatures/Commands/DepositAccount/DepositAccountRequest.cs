using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;

public sealed record DepositAccountRequest(int Id, decimal Amount) : IRequest<DepositAccountResponse>;
