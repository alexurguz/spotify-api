using SpotifyApi.Core.Entities;
using SpotifyApi.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SpotifyApi.Infrastructure.Data
{
    public partial class ApiSpotifyContext : DbContext
    {
        public ApiSpotifyContext()
        {
        }

        public ApiSpotifyContext(DbContextOptions<ApiSpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongsArtists> SongsArtists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());

            modelBuilder.ApplyConfiguration(new SongConfiguration());

            modelBuilder.ApplyConfiguration(new SongsArtistsConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
