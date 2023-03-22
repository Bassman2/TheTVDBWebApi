namespace TheTVDBWebApi
{
    /// <summary>
    /// Search by remote reuslt is a base record for a movie, series, people, season or company search result.
    /// </summary>
    public class SearchByRemoteIdResult
    {
        [JsonPropertyName("series")]
        public SeriesBaseRecord Series { get; set; }

        [JsonPropertyName("people")]
        public PeopleBaseRecord People { get; set; }

        [JsonPropertyName("movie")]
        public MovieBaseRecord Movie { get; set; }

        [JsonPropertyName("episode")]
        public EpisodeBaseRecord Episode { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }
    }
}
