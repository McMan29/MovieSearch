namespace MovieSearch.Server.Service
{
    using Microsoft.Extensions.Options;
    using MovieSearch.Server.Configuration;
    using MovieSearch.Server.Models;
    using MovieSearch.Server.Service.Interface;
    using RestSharp;
    /// <summary>
    /// Movie service logic
    /// </summary>
    public sealed class MovieService : IMovieService
    {
        private readonly IOptions<MovieApiConfiguration> _movieApiConfiguration;
        private const string _apiKeyParameterName = "apikey"; 
        public MovieService(IOptions<MovieApiConfiguration> movieApiConfiguration) {
            _movieApiConfiguration = movieApiConfiguration ?? throw new ArgumentNullException(nameof(movieApiConfiguration));
        }

        public async ValueTask<MovieSearchByTitleResponse> GetMovieInfoAsync(string movieTitle)
        {
             return  await ExecuteRequest<MovieSearchByTitleResponse>("s", movieTitle).ConfigureAwait(false);
        }

        public async ValueTask<MovieDetails> GetMovieDetailsAsync(string id)
        {
             return  await ExecuteRequest<MovieDetails>("i", id).ConfigureAwait(false);
        }

        private async ValueTask<T> ExecuteRequest<T>(string parameterName, string parameterValue)
        {
            using (RestClient client = new RestClient(_movieApiConfiguration.Value.ServiceUrl))
            {
                var res = await client.ExecuteAsync<T>(CreateRequest(Method.Get, parameterName, parameterValue)).ConfigureAwait(false);

                if (res.IsSuccessStatusCode && res.Data != null)
                {
                    var result = res.Data;
                    return result;
                }
                else
                {
                    throw new InvalidOperationException($"Error occurs while calling movie api: {res.ErrorMessage}, {res.ErrorException.Message} ");
                }
            }
        }

        private RestRequest CreateRequest(Method method, string parameterName, string parameterValue)
        {
            RestRequest request = new RestRequest("", method);
            request.AddParameter(Parameter.CreateParameter(name: parameterName,
                value: parameterValue, type: ParameterType.QueryString));
            request.AddParameter(Parameter.CreateParameter(name: _apiKeyParameterName,
                value: _movieApiConfiguration.Value.ApiKey, type: ParameterType.QueryString));

            return request;
        }
    }
}
