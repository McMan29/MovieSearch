namespace MovieSearch.Server.Models
{
    /// <summary>
    /// Movie search by title response 
    /// </summary>
    public sealed record MovieSearchByTitleResponse : ResponseObject
    {
        /// <summary>
        /// Gets or sets list on MovieInfo object.
        /// </summary>
        /// <value>
        /// The list on MovieInfo object.
        /// </value>
        public ICollection<MovieInfo> Search { get; set; } = new List<MovieInfo>();
        /// <summary>
        /// Gets or sets total result count.
        /// </summary>
        /// <value>
        /// The total result count.
        /// </value>
        public int totalResults { get; set; } = default!;
        /// <summary>
        /// Gets or sets the response value.
        /// </summary>
        /// <value>
        /// The response value.
        /// </value>
    }
}
