using System;
using System.Collections.Generic;

namespace SpotifyApi.Core.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            SongsArtists = new HashSet<SongsArtists>();
        }

        public string Id { get; set; }
        public string ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        public virtual ICollection<SongsArtists> SongsArtists { get; set; }
    }
}
