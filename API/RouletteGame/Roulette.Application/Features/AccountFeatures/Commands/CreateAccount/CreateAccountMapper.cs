using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
public sealed class CreateAccountMapper : Profile
{
    public CreateAccountMapper()
    {
        CreateMap<CreateAccountRequest, Account>();
        CreateMap<Account, CreateAccountResponse>();
    }
}
