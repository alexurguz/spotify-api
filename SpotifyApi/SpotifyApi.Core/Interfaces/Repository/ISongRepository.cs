using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;

namespace SpotifyApi.Core.Interfaces.Repository
{
    public interface ISongRepository
    {
        IEnumerable<Song> GetSongsByArtists(string artistName);
        Task<Song> GetSongsById(string songId);
        Task Insertsong(Song song);
    }
}
