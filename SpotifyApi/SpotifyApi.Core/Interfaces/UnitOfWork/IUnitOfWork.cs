using System;
using System.Threading.Tasks;
using SpotifyApi.Core.Interfaces.Repository;

namespace SpotifyApi.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository SongRepository { get; }
        IArtistRepository ArtistRepository { get; }
        ISongsArtistsRepository SongsArtistsRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
