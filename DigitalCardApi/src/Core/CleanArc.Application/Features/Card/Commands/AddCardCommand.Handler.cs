using CleanArc.Application.Contracts.Identity;
using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Models.Common;
using CleanArc.Domain.Entities.Card;
using Mediator;

namespace CleanArc.Application.Features.Card.Commands
{
    internal class AddCardCommandHandler : IRequestHandler<AddCardCommand, OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserManager _userManager;

        public AddCardCommandHandler(IUnitOfWork unitOfWork, IAppUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async ValueTask<OperationResult<bool>> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserByIdAsync(request.UserId);
            if (user == null)
                return OperationResult<bool>.FailureResult("User Not Found");

            var userCardsCount = await _unitOfWork.CardRepository.CountUserCardsAsync(request.UserId);
            if (userCardsCount >= 5)
                return OperationResult<bool>.FailureResult("You cannot create more than 5 cards.");

            var businessCard = new BusinessCard
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Title = request.Title,
                Company = request.Company,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Website = request.Website,
                ProfileImageUrl = request.ProfileImageUrl,
                UserId = user.Id,
                SocialMediaLinks = request.SocialMediaLinks.ToList(),
                ContactOptions = request.ContactOptions.ToList(),
                CustomFields = request.CustomFields.ToList(),
                IsDeleted = false
            };

            await _unitOfWork.CardRepository.AddCardAsync(businessCard);
            await _unitOfWork.CommitAsync();

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}