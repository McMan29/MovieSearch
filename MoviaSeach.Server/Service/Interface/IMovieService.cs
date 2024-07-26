namespace MovieSearch.Server.Service.Interface
{
    using MovieSearch.Server.Models;
    /// <summary>
    /// Movie service interface
    /// </summary>
    public interface IMovieService
    {
        ValueTask<MovieSearchByTitleResponse> GetMovieInfoAsync(string movieTitle);
        ValueTask<MovieDetails> GetMovieDetailsAsync(string id);
    }
}
