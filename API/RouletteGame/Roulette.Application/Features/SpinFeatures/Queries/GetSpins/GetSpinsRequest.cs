using MediatR;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpins;
public sealed record GetSpinsRequest : IRequest<List<GetSpinsResponse>>;