using MediatR;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
public sealed record GetAccountsRequest : IRequest<List<GetAccountsResponse>>;