using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;


public sealed record CreateAccountRequest(string FirstName, string LastName, string UserName, decimal Balance, string Currency) : IRequest<CreateAccountResponse>;
