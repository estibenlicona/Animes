using Newtonsoft.Json;

namespace Anime.Domain.Serializers
{
    public class Data
    {
        [JsonProperty("mal_id")]
        public int? Id { get; set; } = default!;
        public string? Title { get; set; } = default!;
        public Images? Images { get; set; } = default!;
        public decimal? Score { get; set; } = default!;
    }
}
