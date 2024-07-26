namespace MovieSearch.Server.Models
{
    /// <summary>
    /// Repsonse object
    /// </summary>
    public record ResponseObject
    {
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
