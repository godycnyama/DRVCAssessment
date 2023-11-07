using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
public sealed class DeleteAccountHandler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
{
    private readonly IAccountService _accountService;

    public DeleteAccountHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
    {
        return await _accountService.DeleteAccount(request.AccountID);
    }
}
