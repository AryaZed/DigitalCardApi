using CleanArc.Application.Features.Order.Queries.GetUserOrders;
using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Queries.GetUserCards
{
    public record GetUserCardsQueryModel(int UserId) : IRequest<OperationResult<List<GetUsersQueryResultModel>>>;
}