using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Entities.Card;
using Newtonsoft.Json;


namespace CleanArc.Infrastructure.Persistence.Configuration.CardConfig
{
    internal class OrderConfig : IEntityTypeConfiguration<BusinessCard>
    {
        public void Configure(EntityTypeBuilder<BusinessCard> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Title).HasMaxLength(100);
            builder.Property(e => e.Company).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Website).HasMaxLength(100);
            builder.Property(e => e.ProfileImageUrl).HasMaxLength(500);
            builder.Property(e => e.UserId).HasMaxLength(50);  // Adjust as needed

            // Configure SocialMediaLinks with a value converter
            builder.Property(e => e.SocialMediaLinks)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<SocialMediaLinks>(v))
                .HasMaxLength(1000);

            // Configure ContactOptions with a value converter
            builder.Property(e => e.ContactOptions)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ContactOptions>(v))
                .HasMaxLength(500);

            // Configure CustomFields with a value converter
            builder.Property(e => e.CustomFields)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<CustomField>>(v))
                .HasMaxLength(2000);
        }
    }
}
