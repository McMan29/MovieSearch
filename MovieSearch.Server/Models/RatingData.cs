namespace MovieSearch.Server.Models
{
    /// <summary>
    /// Rating data object
    /// </summary>
    public sealed record RatingData
    {
        /// <summary>
        /// Gets or sets the rating source.
        /// </summary>
        /// <value>
        /// The raiting source.
        /// </value>
        public string Source { get; init; } = default!;
        /// <summary>
        /// Gets or sets the rating value.
        /// </summary>
        /// <value>
        /// The rating value.
        /// </value>
        public string Value { get; init; } = default!;
    }
}
