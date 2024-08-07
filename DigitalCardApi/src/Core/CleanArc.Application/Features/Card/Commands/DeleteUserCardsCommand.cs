using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Commands
{
    public record DeleteUserCardsCommand(int UserId) : IRequest<OperationResult<bool>>;
}