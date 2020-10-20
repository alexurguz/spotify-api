using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SpotifyApi.Core.Entities;
using SpotifyApi.Core.Exceptions;
using SpotifyApi.Core.Interfaces.ApiConsumer;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Core.Interfaces.UnitOfWork;
using SpotifyApi.Core.Interfaces.UseCase;

namespace SpotifyApi.Core.UseCase
{
    public class ApiMusicUseCaseImpl : IApiMusicUseCase
    {

        private readonly IApiMusicRepository _apiMusicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApiMusicUseCaseImpl(IApiMusicRepository apiMusicRepository, IUnitOfWork unitOfWork) {
            _apiMusicRepository = apiMusicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Object> ProcessApi(string artistsIds)
        {
            var token = await _apiMusicRepository.RefreshToken();
            var artists = await _apiMusicRepository.GetArtistsByIds(artistsIds, token.ToString());

            if (artists.Count == 0) {
                throw new NotFoundException("Artists not found");
            }

            foreach (JObject jsonArtists in artists.Children<JObject>())
            {
               Artist artist = new Artist
                {
                    Id = jsonArtists["id"].ToString(),
                    Name = jsonArtists["name"].ToString(),
                    ExternalUrls = jsonArtists["external_urls"].ToString(),
                    Href = jsonArtists["href"].ToString(),
                    Type = jsonArtists["type"].ToString(),
                    Uri = jsonArtists["uri"].ToString()
               };

                await _unitOfWork.ArtistRepository.InsertArtist(artist);

                string nextPageAlbums = "start";
                int offSetAlbums = 0;

                token = await _apiMusicRepository.RefreshToken();

                while (nextPageAlbums != null)
                {
                    var resultAlbums = await _apiMusicRepository.GetAlbumsByArtist(artist.Id, token.ToString(), offSetAlbums);
                    var albums = resultAlbums["items"];
                    offSetAlbums += 20;
                    nextPageAlbums = (string)resultAlbums["next"];

                    // albums by artist
                    foreach (JObject jsonAlbums in albums.Children<JObject>())
                    {
                        string nextPageSongs = "start";
                        int offSetSongs = 0;

                        List<Song> listSongs = new List<Song>();
                        List<SongsArtists> listSongsArtists = new List<SongsArtists>();

                        while (nextPageSongs != null)
                        {
                            var resultSongs = await _apiMusicRepository.GetSongsByAlbum(jsonAlbums["id"].ToString(), token.ToString(), offSetSongs);
                            var songs = resultSongs["items"];
                            offSetSongs += 20;
                            nextPageSongs = (string)resultSongs["next"];

                            // songs by album
                            foreach (JObject jsonSongs in songs.Children<JObject>())
                            {
                                if ( !await _unitOfWork.SongRepository.ExistSong(jsonSongs["id"].ToString()) ) {

                                    Song song = new Song
                                    {
                                        Id = jsonSongs["id"].ToString(),
                                        DiscNumber = (int)jsonSongs["disc_number"],
                                        DurationMs = (int)jsonSongs["duration_ms"],
                                        Explicit = (bool)jsonSongs["explicit"],
                                        ExternalUrls = jsonSongs["external_urls"].ToString(),
                                        Href = jsonSongs["href"].ToString(),
                                        IsLocal = (bool)jsonSongs["is_local"],
                                        Name = jsonSongs["name"].ToString(),
                                        PreviewUrl = jsonSongs["preview_url"].ToString(),
                                        Type = jsonSongs["type"].ToString(),
                                        Uri = jsonSongs["uri"].ToString(),
                                        IsPlayable = true,
                                        TrackNumber = (int)jsonSongs["track_number"]
                                    };

                                    SongsArtists songsArtists = new SongsArtists
                                    {
                                        IdArtist = artist.Id,
                                        IdSong = jsonSongs["id"].ToString()
                                    };

                                    listSongs.Add(song);
                                    listSongsArtists.Add(songsArtists);
                                }
                            }

                            if (nextPageSongs == null && listSongs.Count > 0)
                            {
                                await _unitOfWork.SongRepository.Insertsong(listSongs);
                                await _unitOfWork.SongsArtistsRepository.InsertSongArtist(listSongsArtists);
                            }
                        }
                    }
                }
            }
            return "Finish";
        }

    }
}
