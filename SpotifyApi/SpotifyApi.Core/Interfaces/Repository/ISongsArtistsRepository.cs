using System;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;

namespace SpotifyApi.Core.Interfaces.Repository
{
    public interface ISongsArtistsRepository
    {
        Task InsertSongArtist(SongsArtists songsArtists);
    }
}
