using CleanArc.Domain.Common;

namespace CleanArc.Domain.Entities.Card
{
    public class BusinessCard : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string ProfileImageUrl { get; set; }
        public SocialMediaLinks SocialMediaLinks { get; set; }
        public ContactOptions ContactOptions { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public string UserId { get; set; }  // New field for UserId
    }
}
