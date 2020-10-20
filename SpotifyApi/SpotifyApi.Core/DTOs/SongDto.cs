using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SpotifyApi.Core.DTOs
{
    public class SongDto
    {
        public SongDto()
        {
        }

        public string id { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        [DisplayName("explicit")]
        public bool Explicit { get; set; }
        public dynamic external_urls { get; set; }
        public string href { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }

        public virtual ICollection<ArtistDto> Artists { get; set; }
    }
}
