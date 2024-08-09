using CleanArc.Domain.Common;
using System.Text.Json.Serialization;

namespace CleanArc.Domain.Entities.Card
{
    public class SocialMediaLinks : BaseEntity
    {
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Github { get; set; }

        public int BusinessCardId { get; set; }

        [JsonIgnore]    
        public BusinessCard BusinessCard { get; set; }
    }
}
