using Anime.Domain.DTOs;
using Anime.Domain.Ports;
using Anime.Domain.Serializers;
using AutoMapper;
using MediatR;
using Naruto.Application.Anime.Queries;
using Naruto.Domain.Ports;

namespace Naruto.Application.Anime.Handlers
{
    public class SearchAnimeQueryHandler : IRequestHandler<SearchAnimeQuery, QueryResultDto>
    {
        private readonly IAnimeAdapter _animeRepository;
        private readonly IAnimeRulesService _animeRulesService;
        private readonly IMapper _mapper;
        public SearchAnimeQueryHandler(IAnimeAdapter animeRepository, IMapper mapper, IAnimeRulesService animeRulesService)
        {
            _animeRepository = animeRepository;
            _animeRulesService = animeRulesService;
            _mapper = mapper;
        }
        public async Task<QueryResultDto> Handle(SearchAnimeQuery request, CancellationToken cancellationToken)
        {
            QueryResult queryResult = await _animeRepository.Search(request.Query);
            QueryResultDto queryResultDto = _mapper.Map<QueryResultDto>(queryResult);
            queryResultDto = _animeRulesService.ValidateBusinessRules(queryResultDto);
            return queryResultDto;
        }
    }
}
