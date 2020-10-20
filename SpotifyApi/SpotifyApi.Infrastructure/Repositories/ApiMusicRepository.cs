using System;
using System.Threading.Tasks;
using SpotifyApi.Core.Interfaces.ApiConsumer;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace SpotifyApi.Infrastructure.Repositories
{
    public class ApiMusicRepository : IApiMusicRepository
    { 
        public async Task<Object> RefreshToken()
        {
            try
            {
                var client = new RestClient(Utilities.Constants.URL_API_TOKEN);
                var request = new RestRequest(Utilities.Constants.REFRESH_TOKEN, Method.POST);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", Utilities.Constants.TOKEN);
                request.AddParameter("grant_type", Utilities.Constants.TOKEN_GRANT_TYPE, ParameterType.GetOrPost);
                request.AddParameter("refresh_token", Utilities.Constants.REFRESH_TOKEN_VALUE,  ParameterType.GetOrPost);
                IRestResponse response = await client.ExecuteAsync(request);
                JObject JSONContent = Utilities.Utilities.convertToJsonProperties(response.Content);

                return JSONContent["access_token"];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JArray> GetArtistsByIds(string artistsIds, string apiToken)
        {
            try
            {
                var client = new RestClient(Utilities.Constants.URL_API_MUSIC);
                var request = new RestRequest(Utilities.Constants.GET_ARTISTS_BY_IDS, Method.GET);

                request.AddHeader("Authorization", $"Bearer {apiToken}");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("ids", artistsIds, ParameterType.GetOrPost);
                IRestResponse response = await client.ExecuteAsync(request);
                JObject JSONContent = Utilities.Utilities.convertToJsonProperties(response.Content);

                return (JArray)JSONContent["artists"];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JObject> GetAlbumsByArtist(string artistId, string apiToken, int offSet)
        {
            try
            {
                var client = new RestClient(Utilities.Constants.URL_API_MUSIC);
                var request = new RestRequest(Utilities.Constants.GET_ALBUMS_BY_ARTIST.Replace("{id}", artistId), Method.GET);

                request.AddHeader("Authorization", $"Bearer {apiToken}");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("limit", 20, ParameterType.GetOrPost);
                request.AddParameter("offset", offSet, ParameterType.GetOrPost);
                IRestResponse response = await client.ExecuteAsync(request);
                JObject JSONContent = Utilities.Utilities.convertToJsonProperties(response.Content);

                return JSONContent;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JObject> GetSongsByAlbum(string albumId, string apiToken, int offSet)
        {
            try
            {
                var client = new RestClient(Utilities.Constants.URL_API_MUSIC);
                var request = new RestRequest(Utilities.Constants.GET_TRACKS_BY_ALBUM.Replace("{id}", albumId), Method.GET);

                request.AddHeader("Authorization", $"Bearer {apiToken}");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("limit", 20, ParameterType.GetOrPost);
                request.AddParameter("offset", offSet, ParameterType.GetOrPost);
                IRestResponse response = await client.ExecuteAsync(request);
                JObject JSONContent = Utilities.Utilities.convertToJsonProperties(response.Content);

                return JSONContent;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
