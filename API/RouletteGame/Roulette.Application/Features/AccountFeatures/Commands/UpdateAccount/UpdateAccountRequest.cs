using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;

public sealed record UpdateAccountRequest(int AccountID,string FirstName,string LastName, string UserName, decimal Balance, string Currency) : IRequest<UpdateAccountResponse>;
