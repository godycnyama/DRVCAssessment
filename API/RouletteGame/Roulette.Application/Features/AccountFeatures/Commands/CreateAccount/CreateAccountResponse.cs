﻿using Roulette.Application.Common.Models;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
public class CreateAccountResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
}
