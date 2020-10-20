using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Infrastructure.Data;
using EFCore.BulkExtensions;
using System.Collections.Generic;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class SongsArtistsRepository : ISongsArtistsRepository
    {
        private readonly ApiSpotifyContext _context;
        public SongsArtistsRepository(ApiSpotifyContext context)
        {
            _context = context;
        }

        public async  Task InsertSongArtist(List<SongsArtists> listSongsArtists)
        {
            await _context.BulkInsertAsync<SongsArtists>(listSongsArtists);
        }
    }
}
