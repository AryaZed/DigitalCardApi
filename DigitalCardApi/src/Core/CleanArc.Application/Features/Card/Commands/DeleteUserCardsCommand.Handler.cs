using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Commands
{
    public class DeleteUserCardsCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCardsCommand, OperationResult<bool>>
    {
        public async ValueTask<OperationResult<bool>> Handle(DeleteUserCardsCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CardRepository.DeleteUserCardsAsync(request.UserId);

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}