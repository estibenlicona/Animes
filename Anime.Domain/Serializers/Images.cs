using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Anime.Domain.Serializers
{
    public class Images
    {
        public Webp Webp { get; set; } = default!;
    }

    public class Webp
    {
        [JsonProperty("large_image_url")]
        public string? ImageUrl { get; set; } = default!;
    }
}
