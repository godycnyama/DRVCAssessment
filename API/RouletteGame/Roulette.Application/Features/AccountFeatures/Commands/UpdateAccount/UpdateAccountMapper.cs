using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
public sealed class UpdateAccountMapper : Profile
{
    public UpdateAccountMapper()
    {
        CreateMap<UpdateAccountRequest, Account>();
        CreateMap<Account, UpdateAccountResponse>();
    }
}
