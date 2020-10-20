using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpotifyApi.Core.CustomEntities;
using SpotifyApi.Core.DTOs;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Exceptions;
using SpotifyApi.Core.Interfaces.UnitOfWork;
using SpotifyApi.Core.Interfaces.UseCase;
using SpotifyApi.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace SpotifyApi.Core.UseCase
{
    public class SongUseCaseImpl : ISongUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public SongUseCaseImpl(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<SongDto> GetSongById(string songId)
        {
            var artists = _unitOfWork.ArtistRepository.GetArtistsBySong(songId);
            if ( Utilities.Utilities.IsIENumerableEmpty<Artist>(artists) )
            {
                throw new NotFoundException("Song not found");
            }
                
            var song = await _unitOfWork.SongRepository.GetSongsById(songId);

            if (song == null) {
                throw new NotFoundException("song not found");
            }

            List<ArtistDto> artistsDto = artists.Select(ar => new ArtistDto
            {
                Id = ar.Id,
                ExternalUrls = Utilities.Utilities.convertToJson(song.ExternalUrls),
                Href = ar.Href,
                Name = ar.Name,
                Type = ar.Type,
                Uri = ar.Uri
            }).ToList();

            SongDto songDto = new SongDto {

                id = song.Id,
                disc_number = song.DiscNumber,
                duration_ms = song.DurationMs,
                Explicit = song.Explicit,
                external_urls = Utilities.Utilities.convertToJson(song.ExternalUrls),
                href = song.Href,
                is_local = song.IsLocal,
                is_playable = song.IsPlayable,
                name = song.Name,
                preview_url = song.PreviewUrl,
                track_number = song.TrackNumber,
                type = song.Type,
                uri = song.Uri,
                Artists = artistsDto
            };

            return songDto;

        }

        public PagedList<Song> GetSongsByArtists(SongQueryFilter filters)
        {
            filters.pageNumber = ( filters.pageNumber == 0 || filters.pageNumber == null ) ? _paginationOptions.DefaultPageNumber : filters.pageNumber;
            filters.pageSize = ( filters.pageSize == 0 || filters.pageSize == null ) ? _paginationOptions.DefaultPageSize : filters.pageSize;

            var songs = _unitOfWork.SongRepository.GetSongsByArtists(filters.artistName);
            if ( Utilities.Utilities.IsIENumerableEmpty<Song>(songs) ) {
                throw new NotFoundException("Songs not found");
            }

            var pagedSongs = PagedList<Song>.Create(songs, (int)filters.pageNumber, (int)filters.pageSize);
            return pagedSongs;
        }

        public Task Insertsong(Song song)
        {
            throw new NotImplementedException();
        }
    }
}
