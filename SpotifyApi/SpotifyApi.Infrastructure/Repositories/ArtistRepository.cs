using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Infrastructure.Data;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
   
        private readonly ApiSpotifyContext _context;
        public ArtistRepository(ApiSpotifyContext context)
        {
            _context = context;
        }

        public IEnumerable<Artist> GetArtistsBySong(string songId)
        {
            var query = "SELECT DISTINCT [ApiSpotify].[dbo].[Artist].* " +
                        "FROM [ApiSpotify].[dbo].[Song] " +
                        "INNER JOIN [ApiSpotify].[dbo].[SongsArtists] " +
                        "ON [ApiSpotify].[dbo].[Song].[id] = [ApiSpotify].[dbo].[SongsArtists].[id_song] " +
                        "INNER JOIN [ApiSpotify].[dbo].[Artist] " +
                        "ON [ApiSpotify].[dbo].[SongsArtists].[id_artist] = [ApiSpotify].[dbo].[Artist].[id]" +
                        "WHERE [ApiSpotify].[dbo].[Song].[id] = '" + songId + "' ;";

            var artists = _context.Artist.FromSqlRaw(query).AsEnumerable();

            return artists;
        }

        public async Task InsertArtist(Artist artist)
        {
            try
            {
                if (_context.Artist.Any(ar => ar.Id == artist.Id)) return;
                _context.Artist.Add(artist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error " + ex.StackTrace);
            }

        }


        public async Task<Artist> GetArtistById(string artistId)
        {
            var artist = await _context.Artist.FirstOrDefaultAsync(ar => ar.Id == artistId);

            return artist;
        }
    }
}
