using System;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;
using System.Collections.Generic;

namespace SpotifyApi.Core.Interfaces.Repository
{
    public interface ISongsArtistsRepository
    {
        Task InsertSongArtist(List<SongsArtists> listSongsArtists);
    }
}
