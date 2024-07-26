namespace MovieSearch.Server.Models
{
    /// <summary>
    /// Movie details
    /// </summary>
    public sealed record MovieDetails : MovieInfo
    {
        /// <summary>
        /// Gets or sets the movie rated.
        /// </summary>
        /// <value>
        /// The movie rated.
        /// </value>
        public string Rated { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie released.
        /// </summary>
        /// <value>
        /// The movie released.
        /// </value>
        public string Released { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie runtime.
        /// </summary>
        /// <value>
        /// The movie runtime.
        /// </value>
        public string Runtime { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie genre.
        /// </summary>
        /// <value>
        /// The movie genre.
        /// </value>
        /// 
        public string Genre { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie director.
        /// </summary>
        /// <value>
        /// The movie director.
        /// </value>
        public string Director { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie writer.
        /// </summary>
        /// <value>
        /// The movie writer.
        /// </value>
        public string Writer { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie actors.
        /// </summary>
        /// <value>
        /// The movie actors.
        /// </value>
        public string Actors { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie plot.
        /// </summary>
        /// <value>
        /// The movie plot.
        /// </value>
        public string Plot { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie language.
        /// </summary>
        /// <value>
        /// The movie language.
        /// </value>
        public string Language { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie country.
        /// </summary>
        /// <value>
        /// The movie country.
        /// </value>
        public string Country { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie awards.
        /// </summary>
        /// <value>
        /// The movie awards.
        /// </value>
        public string Awards { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie list of ratings.
        /// </summary>
        /// <value>
        /// The movie list of ratings.
        /// </value>
        public ICollection<RatingData> Ratings { get; init; } = new List<RatingData>();
        /// <summary>
        /// Gets or sets the movie metascore.
        /// </summary>
        /// <value>
        /// The movie metascore.
        /// </value>
        public string Metascore { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie imdb rating.
        /// </summary>
        /// <value>
        /// The movie imdb rating.
        /// </value>
        public string ImdbRating { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie dvd.
        /// </summary>
        /// <value>
        /// The movie dvd.
        /// </value>
        public string ImdbVotes { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie rated.
        /// </summary>
        /// <value>
        /// The movie rated.
        /// </value>
        public string DVD { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie boxOffice.
        /// </summary>
        /// <value>
        /// The movie boxOffice.
        /// </value>
        public string BoxOffice { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie production.
        /// </summary>
        /// <value>
        /// The movie production.
        /// </value>
        public string Production { get; init; } = default!;
        /// <summary>
        /// Gets or sets the movie website.
        /// </summary>
        /// <value>
        /// The movie website.
        /// </value>
        public string Website { get; init; } = default!;
        /// <summary>
        /// Gets or sets the response value.
        /// </summary>
        /// <value>
        /// The response value.
        /// </value>
        public string Response { get; init; } = default!;
        /// <summary>
        /// Gets or sets error details. 
        /// </summary>
        /// <value>
        /// The error details.
        /// </value>
        public string Error { get; set; } = default!;
    }
}
