using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SpotifyApi.Core.DTOs;
using SpotifyApi.Api.Response;
using SpotifyApi.Core.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Core.QueryFilters;
using Newtonsoft.Json;
using SpotifyApi.Core.CustomEntities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotifyApi.Api.Controllers
{
    [ApiController]
    public class ApiMusicController : Controller
    {
        private readonly IApiMusicUseCase _apiMusicUseCase;

        public ApiMusicController(IApiMusicUseCase apiMusicUseCase)
        {
            _apiMusicUseCase = apiMusicUseCase;
        }

        [Route("api/artists")]
        [HttpGet]
        public async Task<IActionResult> GetSongById([FromQuery]string artistsIds)
        {
            var artists = await _apiMusicUseCase.ProcessApi(artistsIds);
            return Ok(artists);
        }
    }
}
