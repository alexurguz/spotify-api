using SpotifyApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SpotifyApi.Infrastructure.Data.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public SongConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.DiscNumber).HasColumnName("disc_number");

            builder.Property(e => e.DurationMs).HasColumnName("duration_ms");

            builder.Property(e => e.Explicit).HasColumnName("explicit");

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

            builder.Property(e => e.IsLocal).HasColumnName("is_local");

            builder.Property(e => e.IsPlayable).HasColumnName("is_playable");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.PreviewUrl)
                .IsRequired()
                .HasColumnName("preview_url")
                .HasMaxLength(4000)
                .IsUnicode(false);

            builder.Property(e => e.TrackNumber).HasColumnName("track_number");

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
