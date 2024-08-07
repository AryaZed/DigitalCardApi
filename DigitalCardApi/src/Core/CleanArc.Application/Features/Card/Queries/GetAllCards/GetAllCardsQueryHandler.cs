using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Features.Order.Queries.GetAllOrders;
using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Queries.GetAllCards
{
    internal class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, OperationResult<List<GetAllCardsQueryResult>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCardsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<OperationResult<List<GetAllCardsQueryResult>>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var cards = await _unitOfWork.CardRepository.GetAllCardsWithRelatedUserAsync();

            var result = cards.Select(c => new GetAllCardsQueryResult(
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

            return OperationResult<List<GetAllCardsQueryResult>>.SuccessResult(result);
        }
    }
}
