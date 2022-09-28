using Anime.Domain.DTOs;

namespace Anime.Domain.Ports
{
    public interface IAnimeRulesService
    {
        QueryResultDto ValidateBusinessRules(QueryResultDto queryResult);
    }
}
