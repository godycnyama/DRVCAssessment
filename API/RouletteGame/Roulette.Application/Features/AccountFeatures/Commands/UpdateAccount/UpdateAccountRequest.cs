using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;

public sealed record UpdateAccountRequest(int Id,string FirstName,string LastName, string UserName, decimal Balance) : IRequest<UpdateAccountResponse>;
