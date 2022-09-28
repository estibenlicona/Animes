using Anime.Domain.DTOs;
using Anime.Domain.Ports;

namespace Anime.Domain.Services
{
    public class AnimeRulesService : IAnimeRulesService
    {
        public QueryResultDto ValidateBusinessRules(QueryResultDto queryResult)
        {
            queryResult.Animes = queryResult.Animes.Select(x => new AnimeDto
            {
                Id = x.Id,
                Image = x.Image,
                Title = x.Title,
                Score = x.Score,
                Recommend = ValideRecomendations(x.Score)
            }).ToList();

            return queryResult;
        }
        public string ValideRecomendations(decimal? score)
        {
            string recommend = "No score";
            if (score == null) return recommend;
            if (score >= 1 && score < 5) return "I do not recommend it";
            if (score >= 5 && score < 7) return "You may have fun";
            if (score >= 7) return "Great, this is one of the best anime";
            return recommend;
        }
    }
}
