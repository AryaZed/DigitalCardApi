using CleanArc.Domain.Common;

namespace CleanArc.Domain.Entities.Card
{
    public class CustomField : BaseEntity
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public int BusinessCardId { get; set; }
        public BusinessCard BusinessCard { get; set; }
    }
}
