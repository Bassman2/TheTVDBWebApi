namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Search filter class.
    /// </summary>
    public class SearchFilter
    {
        /// <summary>
        /// The primary search string, which can include the main title for a record including all translations and aliases.
        /// </summary>
        public string Query { get; set; } = null;

        /// <summary>
        /// Alias of the "query" parameter. Recommend using query instead as this field will eventually be deprecated.
        /// </summary>
        public string Q { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific entity type. Can be movie, series, person, or company.
        /// </summary>
        public string Type { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific year. Currently only used for series and movies.
        /// </summary>
        public int? Year { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific company (original network, production company, studio, etc). As an example, "The Walking Dead" would have companies of "AMC", "AMC+", and "Disney+".
        /// </summary>
        public string Company { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific country of origin. Should contain a 3 character country code. Currently only used for series and movies. 
        /// </summary>
        /// <example>usa</example>
        public string Country { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific director. Generally only used for movies. Should include the full name of the director, such as "Steven Spielberg".
        /// </summary>
        public string Director { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific primary language. Should include the 3 character language code. Currently only used for series and movies.
        /// </summary>
        /// <example>eng</example>
        public string Language { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific type of company. Should include the full name of the type of company, such as "Production Company". Only used for companies.
        /// </summary>
        public string PrimaryType { get; set; } = null;

        /// <summary>
        /// Restrict results to a specific network. Used for TV and TV movies, and functions the same as the company parameter with more specificity.
        /// </summary>
        public string Network { get; set; } = null;

        /// <summary>
        /// Search for a specific remote id. Allows searching for an IMDB or EIDR id, for example.
        /// </summary>
        public string RemoteId { get; set; } = null;                        
        
        internal string Parameter
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.Query != null)
                {
                    sb.Append($"&query={this.Query}");
                }
                if (this.Q != null)
                {
                    sb.Append($"&q={this.Q}");
                }
                if (this.Type != null)
                {
                    sb.Append($"&type={this.Type}");
                }
                if (this.Year != null)
                {
                    sb.Append($"&year={this.Year}");
                }
                if (this.Company != null)
                {
                    sb.Append($"&company={this.Company}");
                }
                if (this.Country != null)
                {
                    sb.Append($"&country ={this.Country}");
                }
                if (this.Director != null)
                {
                    sb.Append($"&director={this.Director}");
                }
                if (this.Language != null)
                {
                    sb.Append($"&lang ={this.Language}");
                }
                if (this.PrimaryType != null)
                {
                    sb.Append($"&primaryType={this.PrimaryType}");
                }
                if (this.Network != null)
                {
                    sb.Append($"&network={this.Network}");
                }
                if (this.RemoteId != null)
                {
                    sb.Append($"&remote_id={this.RemoteId}");
                }
                return sb.ToString().TrimStart('&');
            }
        }
    }
}
