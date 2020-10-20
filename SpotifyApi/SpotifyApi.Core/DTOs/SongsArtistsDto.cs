using System;
namespace SpotifyApi.Core.DTOs
{
    public class SongsArtistsDto
    {
        public SongsArtistsDto()
        {
        }

        public int Id { get; set; }
        public string IdArtist { get; set; }
        public string IdSong { get; set; }
    }
}
