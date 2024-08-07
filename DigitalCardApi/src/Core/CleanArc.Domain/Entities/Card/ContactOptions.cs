using CleanArc.Domain.Common;

namespace CleanArc.Domain.Entities.Card
{
    public class ContactOptions :BaseEntity
    {
        public bool Phone { get; set; }
        public bool Email { get; set; }
        public bool Address { get; set; }

        public int BusinessCardId { get; set; }
        public BusinessCard BusinessCard { get; set; }
    }
}
