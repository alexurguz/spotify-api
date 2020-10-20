using SpotifyApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpotifyApi.Infrastructure.Data.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public ArtistConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.ExternalUrls)
                .IsRequired()
                .HasColumnName("external_urls")
                .HasMaxLength(4000)
                .IsUnicode(false);

            builder.Property(e => e.Href)
                .IsRequired()
                .HasColumnName("href")
                .HasMaxLength(4000)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Uri)
                .IsRequired()
                .HasColumnName("uri")
                .HasMaxLength(4000)
                .IsUnicode(false);
        }
    }
}
