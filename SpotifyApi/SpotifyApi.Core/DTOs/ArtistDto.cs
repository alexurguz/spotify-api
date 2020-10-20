using System;
using System.Collections.Generic;

namespace SpotifyApi.Core.DTOs
{
    public class ArtistDto
    {
        public ArtistDto()
        {
        }

        public string Id { get; set; }
        public dynamic ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
