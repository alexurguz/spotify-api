using System;
using System.Collections.Generic;

namespace SpotifyApi.Core.Entities
{
    public partial class Song
    {
        public Song()
        {
            SongsArtists = new HashSet<SongsArtists>();
        }

        public string Id { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public string ExternalUrls { get; set; }
        public string Href { get; set; }
        public bool IsLocal { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        public virtual ICollection<SongsArtists> SongsArtists { get; set; }
    }
}
