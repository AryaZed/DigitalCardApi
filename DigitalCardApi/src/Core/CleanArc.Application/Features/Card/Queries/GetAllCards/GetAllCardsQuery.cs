using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Queries.GetAllCards
{
    public record GetAllCardsQuery : IRequest<OperationResult<List<GetAllCardsQueryResult>>>;
}