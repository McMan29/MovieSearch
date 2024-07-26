namespace MovieSearch.Server.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using MovieSearch.Server.Service.Interface;

    [ApiController]
    [Route("[controller]")]
    [EnableCors("LocalCorsPolicy")]
    public class MovieSearchController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieSearchController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("GetMoviebyTitle/{title}")]
        public async ValueTask<IActionResult> GetMovieByTitle([FromRoute] string title)
        {
            if (title == null)
                return BadRequest();

            var result = await _movieService.GetMovieInfoAsync(title).ConfigureAwait(false);

            return Ok(result);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("GetMovieDetailsById/{id}")]
        public async ValueTask<IActionResult> GetMovieDetailsById([FromRoute] string id)
        {
            if (id == null)
                return BadRequest();

            var result = await _movieService.GetMovieDetailsAsync(id).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
