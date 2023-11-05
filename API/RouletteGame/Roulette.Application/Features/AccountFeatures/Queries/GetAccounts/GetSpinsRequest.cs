using MediatR;

namespace Roulette.Application.Features.SpinFeatures.GetSpins;
public sealed record GetSpinsRequest : IRequest<List<GetSpinsResponse>>;