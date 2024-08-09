using CleanArc.Domain.Common;
using System.Text.Json.Serialization;

namespace CleanArc.Domain.Entities.Card
{
    public class CustomField : BaseEntity
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public int BusinessCardId { get; set; }

        [JsonIgnore]
        public BusinessCard BusinessCard { get; set; }
    }
}
