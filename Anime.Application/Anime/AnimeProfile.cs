using Anime.Domain.DTOs;
using Anime.Domain.Ports;
using Anime.Domain.Serializers;
using AutoMapper;

namespace Anime.Application.Anime
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {

            CreateMap<Data, AnimeDto>()
                .ForMember(x => x.Image, opt => opt.MapFrom(i => i.Images.Webp.ImageUrl));

            CreateMap<QueryResult, QueryResultDto>()
                .ForMember(x => x.Animes, opt => opt.MapFrom(i => i.Data));
        }
    }
}
