using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Entities.Card;
using Newtonsoft.Json;


namespace CleanArc.Infrastructure.Persistence.Configuration.CardConfig
{
    internal class BusinessCardConfig : IEntityTypeConfiguration<BusinessCard>
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
            builder.Property(e => e.UserId).IsRequired();  // Adjust as needed

            builder.HasOne(c => c.User)
                .WithMany(u => u.BusinessCards)
                .HasForeignKey(c => c.UserId);

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasMany(b => b.SocialMediaLinks)
                .WithOne(s => s.BusinessCard)
                .HasForeignKey(s => s.BusinessCardId);

            builder.HasMany(b => b.ContactOptions)
                .WithOne(c => c.BusinessCard)
                .HasForeignKey(c => c.BusinessCardId);

            builder.HasMany(b => b.CustomFields)
                .WithOne(f => f.BusinessCard)
                .HasForeignKey(f => f.BusinessCardId);
        }
    }

    internal class ContactOptionsConfig : IEntityTypeConfiguration<ContactOptions>
    {
        public void Configure(EntityTypeBuilder<ContactOptions> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Address).IsRequired();

            builder.HasOne(c => c.BusinessCard)
                .WithMany(b => b.ContactOptions)
                .HasForeignKey(c => c.BusinessCardId);
        }
    }

    internal class CustomFieldConfig : IEntityTypeConfiguration<CustomField>
    {
        public void Configure(EntityTypeBuilder<CustomField> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FieldName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.FieldValue).IsRequired().HasMaxLength(200);

            builder.HasOne(c => c.BusinessCard)
                .WithMany(b => b.CustomFields)
                .HasForeignKey(c => c.BusinessCardId);
        }
    }

    internal class SocialMediaLinksConfig : IEntityTypeConfiguration<SocialMediaLinks>
    {
        public void Configure(EntityTypeBuilder<SocialMediaLinks> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.LinkedIn).HasMaxLength(100);
            builder.Property(e => e.Twitter).HasMaxLength(100);
            builder.Property(e => e.Facebook).HasMaxLength(100);
            builder.Property(e => e.Instagram).HasMaxLength(100);
            builder.Property(e => e.Github).HasMaxLength(100);

            builder.HasOne(s => s.BusinessCard)
                .WithMany(b => b.SocialMediaLinks)
                .HasForeignKey(s => s.BusinessCardId);
        }
    }

}
