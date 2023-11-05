using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
public sealed class DeleteAccountHandler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public DeleteAccountHandler(IMapper mapper, IAccountService accountService)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
    {
        return await _accountService.DeleteAccount(request.Id);
    }
}
