using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Interfaces.UnitOfWork;
using SpotifyApi.Core.Interfaces.UseCase;

namespace SpotifyApi.Core.UseCase
{
    public class ArtistUseCaseImpl : IArtistUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistUseCaseImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Artist> GetArtistsBySong(string songId)
        {
            var artists = _unitOfWork.ArtistRepository.GetArtistsBySong(songId);
            return artists;
        }

        public Task InsertArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}