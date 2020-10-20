using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SpotifyApi.Core.Interfaces.ApiConsumer
{
    public interface IApiMusicRepository
    {
        Task<Object> RefreshToken();
        Task<JArray> GetArtistsByIds(string artistsIds, string apiToken);
        Task<JObject> GetAlbumsByArtist(string artistId, string apiToken, int offSet);
        Task<JObject> GetSongsByAlbum(string artistId, string apiToken, int offSet);
    }
}
