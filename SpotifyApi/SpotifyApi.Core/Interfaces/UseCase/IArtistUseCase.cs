using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;

namespace SpotifyApi.Core.Interfaces.UseCase
{
    public interface IArtistUseCase
    {
       
        IEnumerable<Artist> GetArtistsBySong(string songId);
        Task InsertArtist(Artist artist);
    }
}
