using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;

public sealed record CreateAcountRequest(string FirstName, string LastName, string UserName, decimal Balance) : IRequest<CreateAccountResponse>;
