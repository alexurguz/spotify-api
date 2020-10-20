using System;
using SpotifyApi.Core.CustomEntities;

namespace SpotifyApi.Api.Response
{
    public class SongsResponse<T>
    {
        public SongsResponse(T songs)
        {
            Songs = songs;
        }
        public T Songs { get; set; }

        public PaginatorData paginator { get; set; }
    }
}
