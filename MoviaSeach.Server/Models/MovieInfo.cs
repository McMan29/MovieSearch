namespace MovieSearch.Server.Models
{
    /// <summary>
    /// Movie information
    /// </summary>
    public record MovieInfo
    {
        /// <summary>
        /// Gets or sets the movie title.
        /// </summary>
        /// <value>
        /// The movie title.
        /// </value>
        public string Title { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie year.
        /// </summary>
        /// <value>
        /// The movie year.
        /// </value>
        public string Year { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie IMDB ID.
        /// </summary>
        /// <value>
        /// The movie IMDB ID.
        /// </value>
        public string ImdbID { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie type.
        /// </summary>
        /// <value>
        /// The movie type.
        /// </value>
        public string Type { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie poster.
        /// </summary>
        /// <value>
        /// The movie poster.
        /// </value>
        public string Poster { get; init; } = default!;
    }
}
