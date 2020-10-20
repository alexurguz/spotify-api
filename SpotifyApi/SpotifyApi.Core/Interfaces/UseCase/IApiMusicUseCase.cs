using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Core.Entities;

namespace SpotifyApi.Core.Interfaces.UseCase
{
    public interface IApiMusicUseCase
    {
        Task<Object> ProcessApi(string artistsIds);
    }
}
