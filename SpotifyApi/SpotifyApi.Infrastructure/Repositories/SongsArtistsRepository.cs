using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Infrastructure.Data;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class SongsArtistsRepository : ISongsArtistsRepository
    {
        private readonly ApiSpotifyContext _context;
        public SongsArtistsRepository(ApiSpotifyContext context)
        {
            _context = context;
        }

        public async  Task InsertSongArtist(SongsArtists songsArtists)
        {
            try
            {
                if (_context.SongsArtists.Any(sa => sa.IdArtist == songsArtists.IdArtist && sa.IdSong == songsArtists.IdSong)) return;
                _context.SongsArtists.Add(songsArtists);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error " + ex.StackTrace);
            }
        }
    }
}
