using System;
namespace SpotifyApi.Utilities
{
    public static class Constants
    {
        //Constantes de servicios de Icoltrans
        public const string URL_API_MUSIC = "https://api.spotify.com";
        public const string URL_API_TOKEN = "https://accounts.spotify.com";
        public const string REFRESH_TOKEN = "/api/token";
        public const string GET_ARTISTS_BY_IDS = "/v1/artists/";
        public const string GET_ALBUMS_BY_ARTIST = "/v1/artists/{id}/albums";
        public const string GET_TRACKS_BY_ALBUM = "/v1/albums/{id}/tracks";
        public const string TOKEN = "Basic Y2ExM2JiNjFlZjQwNDIzMGFmYjAwNDc1Yzc0MGFmMmQ6YzdhMjU1NWM4MzFhNDM1NTg0OWZiZWZhY2Q3ZjNhMzI=";
        public const string REFRESH_TOKEN_VALUE = "AQDChzFyJ1JI9GBP69xVuDjYOdNGyAPI2ONdmRzBBapxDEJj-JBeh9AbgRhg3SEaShFMwouqxmBcYeIHzOzbjshEEG3hY6Q_wq_wYoT8Lj9O06TGf7Cw50e3clRPdTxQ9rs";
        public const string TOKEN_GRANT_TYPE = "refresh_token";
    }
}
