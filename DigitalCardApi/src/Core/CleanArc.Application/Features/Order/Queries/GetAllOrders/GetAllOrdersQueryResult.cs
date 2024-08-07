using CleanArc.Domain.Entities.Card;

namespace CleanArc.Application.Features.Order.Queries.GetAllOrders
{
    public record GetAllOrdersQueryResult(int id,string orderName, int userId, string userName);

}