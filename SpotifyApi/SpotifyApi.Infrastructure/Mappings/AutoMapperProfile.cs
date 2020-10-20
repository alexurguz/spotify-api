using AutoMapper;
using SpotifyApi.Core.DTOs;
using SpotifyApi.Core.Entities;

namespace Invoice.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Song, SongsDto>().ForMember(dest => dest.songId, opt => opt.MapFrom(src => src.Id))
                                        .ForMember(dest => dest.songTitle, opt => opt.MapFrom(src => src.Name));
        }
    }
}
