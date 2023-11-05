﻿using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;

public sealed record DeletePayoutRequest(int Id) : IRequest<DeletePayoutResponse>;
