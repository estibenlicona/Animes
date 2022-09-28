using Anime.Domain.Serializers;
using Anime.Domain.Validations;
using Naruto.Domain.Ports;
using Naruto.Infrastructure.Configs;
using Newtonsoft.Json;
using System.Globalization;

namespace Naruto.Infrastructure.Adapters
{
    public class AnimeAdapter : IAnimeAdapter
    {
        private readonly ApiJinkaConfig _apiJinkaConfig;
        private readonly HttpClient _httpClient;
        public AnimeAdapter(ApiJinkaConfig apiJinkaConfig, HttpClient httpClient)
        {
            _apiJinkaConfig = apiJinkaConfig;
            _httpClient = httpClient;
        }

        public async Task<QueryResult> Search(string query)
        {
            try
            {
                Uri url = new(String.Format(CultureInfo.InvariantCulture,
                $"{_apiJinkaConfig.EndPoint}{_apiJinkaConfig.AnimeResource}", query));
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                QueryResult queryResultDto = JsonConvert.DeserializeObject<QueryResult>(result) ?? new QueryResult();
                return queryResultDto;
            }
            catch (Exception e)
            {
                throw new ApiJikanException("Ha ocurrido un error consumiendo la api Jikan.");
            }
        }
    }
}
