using CleanArc.Domain.Common;
using System.Text.Json.Serialization;

namespace CleanArc.Domain.Entities.Card
{
    public class ContactOptions :BaseEntity
    {
        public bool Phone { get; set; }
        public bool Email { get; set; }
        public bool Address { get; set; }

        public int BusinessCardId { get; set; }

        [JsonIgnore]
        public BusinessCard BusinessCard { get; set; }
    }
}
