using Anime.Domain.DTOs;
using Anime.Domain.Serializers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Naruto.Application.Anime.Queries;

namespace Naruto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<QueryResultDto> Get([FromQuery] SearchAnimeQuery searchAnimeQuery)
        {
            return await _mediator.Send(searchAnimeQuery);
        }
    }
}