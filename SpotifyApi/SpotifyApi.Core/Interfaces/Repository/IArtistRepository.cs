using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;

namespace SpotifyApi.Core.Interfaces.Repository
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetArtistsBySong(string songId);
        Task InsertArtist(Artist artist);
        Task<Artist> GetArtistById(string artistId);
    }
}
