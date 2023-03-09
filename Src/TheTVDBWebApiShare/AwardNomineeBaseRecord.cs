namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Base award nominee record.
    /// </summary>
    public class AwardNomineeBaseRecord
    {
        [JsonPropertyName("character")]
        public Character Character { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("episode")]
        public EpisodeBaseRecord Episode { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("isWinner")]
        public bool IsWinner { get; set; }

        [JsonPropertyName("movie")]
        public MovieBaseRecord Movie { get; set; }

        [JsonPropertyName("series")]
        public SeriesBaseRecord Series { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
