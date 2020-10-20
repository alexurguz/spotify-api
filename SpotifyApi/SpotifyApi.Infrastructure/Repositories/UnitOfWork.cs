using System.Threading.Tasks;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Core.Interfaces.UnitOfWork;
using SpotifyApi.Infrastructure.Data;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ISongsArtistsRepository _songsArtistsRepository;
        private readonly ApiSpotifyContext _context;

        public UnitOfWork(ApiSpotifyContext context)
        {
            _context = context;
        }


        public ISongRepository SongRepository => _songRepository ?? new SongRepository(_context);
        public IArtistRepository ArtistRepository => _artistRepository ?? new ArtistRepository(_context);
        public ISongsArtistsRepository SongsArtistsRepository => _songsArtistsRepository ?? new SongsArtistsRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
