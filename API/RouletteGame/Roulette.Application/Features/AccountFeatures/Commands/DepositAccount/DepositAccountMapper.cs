using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;
public sealed class DepositAccountMapper : Profile
{
    public DepositAccountMapper()
    {
        CreateMap<DepositAccountRequest, Account>();
        CreateMap<Account, DepositAccountResponse>();
    }
}
