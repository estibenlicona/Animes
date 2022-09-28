using Anime.Domain.Serializers;

namespace Naruto.Domain.Ports
{
    public interface IAnimeAdapter
    {
        Task<QueryResult> Search(string query);
    }
}
