using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Queries.GetUserCards
{
    internal class GetUserCardsQueryHandler : IRequestHandler<GetUserCardsQueryModel, OperationResult<List<GetUsersQueryResultModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserCardsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<OperationResult<List<GetUsersQueryResultModel>>> Handle(GetUserCardsQueryModel request, CancellationToken cancellationToken)
        {
            var cards = await _unitOfWork.CardRepository.GetAllUserCardsAsync(request.UserId);

            if (!cards.Any())
                return OperationResult<List<GetUsersQueryResultModel>>.NotFoundResult("You don't have any cards");

            var result = cards.Select(c => new GetUsersQueryResultModel(
                c.Id,
                c.FirstName,
                c.LastName,
                c.Title,
                c.Company,
                c.PhoneNumber,
                c.Email,
                c.Address,
                c.Website,
                c.ProfileImageUrl,
                c.UserId,
                c.User.UserName,
                c.SocialMediaLinks,
                c.ContactOptions,
                c.CustomFields
            )).ToList();

            return OperationResult<List<GetUsersQueryResultModel>>.SuccessResult(result);
        }
    }
}