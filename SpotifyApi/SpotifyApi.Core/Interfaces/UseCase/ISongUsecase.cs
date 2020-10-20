using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.DTOs;
using SpotifyApi.Core.QueryFilters;
using SpotifyApi.Core.CustomEntities;

namespace SpotifyApi.Core.Interfaces.UseCase
{
    public interface ISongUseCase
    {
        PagedList<Song> GetSongsByArtists(SongQueryFilter filters);
        Task<SongDto> GetSongById(string songId);
        Task Insertsong(Song song);
    }
}