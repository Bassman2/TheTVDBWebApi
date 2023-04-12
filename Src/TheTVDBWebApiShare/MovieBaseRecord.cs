namespace TheTVDBWebApi
{
    /// <summary>
    /// Base movie record.
    /// </summary>
    public class MovieBaseRecord
    {
        /// <summary>
        /// Id of the movie.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the movie.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Uri of a movie image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// Translated names of the movie.
        /// </summary>
        [JsonPropertyName("nameTranslations")]
        public List<Languages> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Languages> OverviewTranslations { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        /// <summary>
        /// Score of the movie.
        /// </summary>
        [JsonPropertyName("score")]
        public double Score { get; set; }

        /// <summary>
        /// Runtime of the movie.
        /// </summary>
        /// <remarks>Can be null if runtime is unknown.</remarks>
        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        /// <summary>
        /// Status of the movie
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Year of the movie.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
