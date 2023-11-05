using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
public sealed class GetAccountsMapper : Profile
{
    public GetAccountsMapper()
    {
        CreateMap<Account, GetAccountsResponse>();
    }
}