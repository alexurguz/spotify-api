using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Infrastructure.Data;
using EFCore.BulkExtensions;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {

        private readonly ApiSpotifyContext _context;
        public SongRepository(ApiSpotifyContext context)
        {
            _context = context;
        }

        public IEnumerable<Song> GetSongsByArtists(string artistName)
        {
            var query = "SELECT DISTINCT [ApiSpotify].[dbo].[Song].* " +
                        "FROM [ApiSpotify].[dbo].[Song] " +
                        "INNER JOIN [ApiSpotify].[dbo].[SongsArtists] " +
                        "ON [ApiSpotify].[dbo].[Song].[id] = [ApiSpotify].[dbo].[SongsArtists].[id_song] " +
                        "INNER JOIN [ApiSpotify].[dbo].[Artist] " +
                        "ON [ApiSpotify].[dbo].[SongsArtists].[id_artist] = [ApiSpotify].[dbo].[Artist].[id]" +
                        "WHERE [ApiSpotify].[dbo].[Artist].[name] LIKE'%" + artistName + "%' ;";

            var songs = _context.Song.FromSqlRaw(query).AsEnumerable();
 
            return songs;
        }
        
        public async Task<Song> GetSongsById(string songId)
        {
            var song = await _context.Song.FirstOrDefaultAsync(so => so.Id == songId);

            return song;
        }

        public async Task Insertsong(List<Song> listSongs)
        {
            await _context.BulkInsertAsync<Song>(listSongs);
        }

        public async Task<bool> ExistSong(string songId)
        {
            bool response = false;
            response = _context.Song.Any(so => so.Id == songId);
            return response;
        }

    }
}
