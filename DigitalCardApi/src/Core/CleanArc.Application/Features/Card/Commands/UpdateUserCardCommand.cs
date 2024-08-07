using CleanArc.Application.Contracts.Identity;
using CleanArc.Application.Contracts.Persistence;
using CleanArc.Application.Features.Order.Commands;
using CleanArc.Application.Models.Common;
using CleanArc.Domain.Entities.Card;
using CleanArc.SharedKernel.ValidationBase;
using CleanArc.SharedKernel.ValidationBase.Contracts;
using FluentValidation;
using Mediator;
using System.Text.Json.Serialization;

namespace CleanArc.Application.Features.Card.Commands
{
    public record UpdateUserCardCommand(
     int CardId,
     string FirstName,
     string LastName,
     string Title,
     string Company,
     string PhoneNumber,
     string Email,
     string Address,
     string Website,
     string ProfileImageUrl,
     IList<SocialMediaLinks> SocialMediaLinks,
     IList<ContactOptions> ContactOptions,
     IList<CustomField> CustomFields
 ) : IRequest<OperationResult<bool>>, IValidatableModel<UpdateUserCardCommand>
    {
        [JsonIgnore]
        public int UserId { get; set; }

        public IValidator<UpdateUserCardCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UpdateUserCardCommand> validator)
        {
            validator.RuleFor(c => c.CardId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Card ID must be greater than 0.");

            validator.RuleFor(c => c.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("First name cannot be empty.");

            validator.RuleFor(c => c.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last name cannot be empty.");

            validator.RuleFor(c => c.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title cannot be empty.");

            validator.RuleFor(c => c.Company)
                .NotEmpty()
                .NotNull()
                .WithMessage("Company cannot be empty.");

            validator.RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone number cannot be empty.");

            validator.RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email cannot be empty.");

            validator.RuleFor(c => c.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Address cannot be empty.");

            validator.RuleFor(c => c.Website)
                .NotEmpty()
                .NotNull()
                .WithMessage("Website cannot be empty.");

            validator.RuleFor(c => c.ProfileImageUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage("Profile image URL cannot be empty.");

            return validator;
        }
    }
}