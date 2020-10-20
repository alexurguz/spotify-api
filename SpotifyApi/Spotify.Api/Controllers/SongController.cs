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
    public class SongController : ControllerBase
    {
        private readonly ISongUseCase _songUseCase;
        private readonly IMapper _mapper;

        public SongController(ISongUseCase songUseCase, IMapper mapper)
        {
            _songUseCase = songUseCase;
            _mapper = mapper;
        }

        [Route("api/songs")]
        [HttpGet]
        public IActionResult GetSongsByArtists([FromQuery]SongQueryFilter filters)
        {
            var songs = _songUseCase.GetSongsByArtists(filters);
            var songsDto = _mapper.Map<IEnumerable<SongsDto>>(songs);

            var paginator = new PaginatorData
            {
                TotalCount = songs.TotalCount,
                PageSize = songs.PageSize,
                CurrentPage = songs.CurrentPage,
                TotalPages = songs.TotalPages,
                HasNextPage = songs.HasNextPage,
                HasPreviousPage = songs.HasPreviousPage
            };

            var response = new SongsResponse<IEnumerable<SongsDto>>(songsDto)
            {
                paginator = paginator
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginator));
            return Ok(response);
        }

        [Route("api/songs/{songId}")]
        [HttpGet]
        public async Task<IActionResult> GetSongById(string songId)
        {
            var songDto = await _songUseCase.GetSongById(songId);
            return Ok(songDto);
        }
    }
}
