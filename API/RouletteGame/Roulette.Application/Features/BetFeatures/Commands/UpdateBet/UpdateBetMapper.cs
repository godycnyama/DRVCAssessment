using AutoMapper;
using Roulette.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.BetFeatures.Commands.UpdateBet;
public sealed class UpdateBetMapper : Profile
{
    public UpdateBetMapper()
    {
        CreateMap<UpdateBetRequest, Bet>();
    }
}
