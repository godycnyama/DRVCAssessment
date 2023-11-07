using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
public sealed record GetAccountRequest(int AccountID) : IRequest<GetAccountResponse>;
