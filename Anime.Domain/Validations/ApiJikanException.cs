using Anime.Domain.Exceptions;

namespace Anime.Domain.Validations
{
    public class ApiJikanException : AppException
    {
        public ApiJikanException(string message) : base(message) { }
    }
}
