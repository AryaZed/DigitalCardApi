using CleanArc.Domain.Entities.Card;

namespace CleanArc.Application.Features.Card.Queries.GetUserCards
{
    public record GetUsersQueryResultModel(
     int Id,
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
     string UserName,
     ICollection<SocialMediaLinks> SocialMediaLinks,
     ICollection<ContactOptions> ContactOptions,
     ICollection<CustomField> CustomFields
 );
}