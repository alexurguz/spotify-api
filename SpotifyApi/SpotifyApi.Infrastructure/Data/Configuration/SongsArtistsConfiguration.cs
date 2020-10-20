using SpotifyApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SpotifyApi.Infrastructure.Data.Configuration
{
    public class SongsArtistsConfiguration : IEntityTypeConfiguration<SongsArtists>
    {
        public SongsArtistsConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<SongsArtists> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IdArtist)
                .IsRequired()
                .HasColumnName("id_artist")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.IdSong)
                .IsRequired()
                .HasColumnName("id_song")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdArtistNavigation)
                .WithMany(p => p.SongsArtists)
                .HasForeignKey(d => d.IdArtist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SA_idArtist");

            builder.HasOne(d => d.IdSongNavigation)
                .WithMany(p => p.SongsArtists)
                .HasForeignKey(d => d.IdSong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SA_idASong");
        }
    }
}
