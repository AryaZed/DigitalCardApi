using CleanArc.Application.Models.Common;
using CleanArc.Domain.Entities.Card;
using CleanArc.SharedKernel.ValidationBase;
using CleanArc.SharedKernel.ValidationBase.Contracts;
using FluentValidation;
using Mediator;
using System.Text.Json.Serialization;

namespace CleanArc.Application.Features.Card.Commands
{
    public record AddCardCommand(
     string FirstName,
     string LastName,
     string Title,
     string Company,
     string PhoneNumber,
     string Email,
     string Address,
     string Website,
     string ProfileImageUrl,
     int UserId,
    IList<SocialMediaLinks> SocialMediaLinks,
    IList<ContactOptions> ContactOptions,
    IList<CustomField> CustomFields
 ) : IRequest<OperationResult<bool>>, IValidatableModel<AddCardCommand>
    {

        public IValidator<AddCardCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCardCommand> validator)
        {
            validator.RuleFor(c => c.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your first name");

            validator.RuleFor(c => c.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your last name");

            validator.RuleFor(c => c.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your title");

            validator.RuleFor(c => c.Company)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your company name");

            validator.RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your phone number");

            validator.RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your email");

            validator.RuleFor(c => c.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your address");

            validator.RuleFor(c => c.Website)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your website");

            validator.RuleFor(c => c.ProfileImageUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please enter your profile image URL");

            validator.RuleFor(c => c.UserId)
                .GreaterThan(0)
                .WithMessage("Please enter a valid user ID");

            return validator;
        }
    }

}