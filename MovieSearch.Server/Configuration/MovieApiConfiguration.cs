namespace MovieSearch.Server.Configuration
{
    /// <summary>
    /// Movie Api configuration
    /// </summary>
    public record MovieApiConfiguration
    {
        /// <summary>
        /// Gets or sets the movie service url.
        /// </summary>
        /// <value>
        /// The movie service url.
        /// </value>
        public string ServiceUrl { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie api key.
        /// </summary>
        /// <value>
        /// The movie api key.
        /// </value>
        public string ApiKey { get; init; } = default!;
    }
}
