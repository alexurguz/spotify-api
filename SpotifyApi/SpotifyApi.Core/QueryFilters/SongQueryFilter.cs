using System;
namespace SpotifyApi.Core.QueryFilters
{
    public class SongQueryFilter
    {
        public string? artistName { get; set; }

        public int? pageSize { get; set; }

        public int? pageNumber { get; set; }
    }
}
