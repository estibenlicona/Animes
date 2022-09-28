using Anime.Domain.DTOs;
using Anime.Domain.Serializers;
using MediatR;

namespace Naruto.Application.Anime.Queries
{
    public class SearchAnimeQuery : IRequest<QueryResultDto>
    {
        public string Query { get; set; } = default!;
    }
}
