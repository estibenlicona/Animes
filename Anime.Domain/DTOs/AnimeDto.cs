using Anime.Domain.Serializers;

namespace Anime.Domain.DTOs
{
    public class AnimeDto
    {
        public int? Id { get; set; } = default!;
        public string? Title { get; set; } = default!;
        public string? Image { get; set; } = default!;
        public decimal? Score { get; set; } = default!;
        public string Recommend { get; set; } = default!;
    }
}
