using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Application.Features.Card.Commands
{
    public class UpdateUserCardCommandHandler : IRequestHandler<UpdateUserCardCommand, OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<OperationResult<bool>> Handle(UpdateUserCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetUserCardByIdAndUserIdAsync(request.UserId, request.CardId, true);

            if (card is null)
                return OperationResult<bool>.NotFoundResult("Specified card not found");

            card.FirstName = request.FirstName;
            card.LastName = request.LastName;
            card.Title = request.Title;
            card.Company = request.Company;
            card.PhoneNumber = request.PhoneNumber;
            card.Email = request.Email;
            card.Address = request.Address;
            card.Website = request.Website;
            card.ProfileImageUrl = request.ProfileImageUrl;
            card.SocialMediaLinks = request.SocialMediaLinks;
            card.ContactOptions = request.ContactOptions;
            card.CustomFields = request.CustomFields;

            await _unitOfWork.CommitAsync();

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}