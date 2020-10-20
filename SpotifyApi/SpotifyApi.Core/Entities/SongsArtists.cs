using System;
using System.Collections.Generic;

namespace SpotifyApi.Core.Entities
{
    public partial class SongsArtists
    {
        
        public int Id { get; set; }
        public string IdArtist { get; set; }
        public string IdSong { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Song IdSongNavigation { get; set; }
        
    }
}
